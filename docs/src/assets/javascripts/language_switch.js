// 260531Ch: Retarget the header language selector to the matching page slug.
// 260625Cl: Generalized from the en/ja-only special case to all languages defined in
//   mkdocs.yml `extra.alternate`. Driven entirely by the `hreflang`/`href` of the rendered
//   language links, so adding a language needs no change here. English is special: its root
//   `/CSManager/` is the home, but its content pages live under `/CSManager/en/`. Every other
//   language L is symmetric: home and content both live under its root `/CSManager/L/`.
//   Language codes may contain '-' (e.g. zh-Hans); they are never split.
(function () {
  "use strict";

  // Map of hreflang -> root href (the language link's href from extra.alternate).
  var roots = null;

  function ensureRoots() {
    if (roots) return true;
    var map = {};
    document.querySelectorAll("a.md-select__link[hreflang]").forEach(function (a) {
      var lang = a.getAttribute("hreflang");
      var href = a.getAttribute("href");
      if (lang && href && map[lang] == null) map[lang] = href;
    });
    if (Object.keys(map).length === 0) return false;
    roots = map;
    return true;
  }

  // The base path under which a language's content pages (non-home) live.
  // English content sits in an `en/` subfolder of its root; all others use their root directly.
  function contentBase(lang) {
    return lang === "en" ? roots[lang] + "en/" : roots[lang];
  }

  // Identify the current page's language and slug (path after the content base; "" for a home page).
  function detectCurrent() {
    var path = window.location.pathname;
    // Home pages (exact root match) first — needed for English whose home `/CSManager/`
    // is not its content base `/CSManager/en/`.
    for (var lang in roots) {
      if (roots.hasOwnProperty(lang) && path === roots[lang]) return { lang: lang, slug: "" };
    }
    // Content pages: longest content base wins so `/CSManager/ja/` beats `/CSManager/`.
    var langs = Object.keys(roots).sort(function (a, b) {
      return contentBase(b).length - contentBase(a).length;
    });
    for (var i = 0; i < langs.length; i++) {
      var base = contentBase(langs[i]);
      if (path.indexOf(base) === 0) return { lang: langs[i], slug: path.slice(base.length) };
    }
    return null;
  }

  function targetFor(lang, cur) {
    if (roots[lang] == null) return null;
    if (cur.slug === "") return roots[lang]; // home of the target language
    return contentBase(lang) + cur.slug;     // same slug under the target language
  }

  function retarget() {
    if (!ensureRoots()) return;
    var cur = detectCurrent();
    if (!cur) return;
    document.querySelectorAll("a.md-select__link[hreflang]").forEach(function (a) {
      var lang = a.getAttribute("hreflang");
      var target = targetFor(lang, cur);
      if (target) a.setAttribute("href", target);
    });
  }

  document.addEventListener("click", function (ev) {
    var link = ev.target && ev.target.closest && ev.target.closest("a.md-select__link[hreflang]");
    if (!link) return;
    if (!ensureRoots()) return;
    var lang = link.getAttribute("hreflang");
    if (roots[lang] == null) return;
    var cur = detectCurrent();
    if (!cur) return;
    var target = targetFor(lang, cur);
    if (!target) return;
    ev.preventDefault();
    window.location.href = target;
  });

  if (typeof window.document$ !== "undefined" && window.document$.subscribe) {
    window.document$.subscribe(retarget);
  } else if (document.readyState !== "loading") {
    retarget();
  } else {
    document.addEventListener("DOMContentLoaded", retarget);
  }
})();
