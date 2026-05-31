// 260531Ch: Configure MathJax for MkDocs Material.
(function () {
  "use strict";

  window.MathJax = {
    loader: { load: ["[tex]/boldsymbol"] },
    tex: {
      packages: { "[+]": ["boldsymbol"] },
      inlineMath: [["\\(", "\\)"], ["$", "$"]],
      displayMath: [["\\[", "\\]"], ["$$", "$$"]],
      processEscapes: true,
      processEnvironments: true
    },
    options: {
      ignoreHtmlClass: ".*|",
      processHtmlClass: "arithmatex"
    }
  };

  function typeset() {
    if (!window.MathJax || !MathJax.typesetPromise) return;
    MathJax.startup.output.clearCache();
    MathJax.typesetClear();
    MathJax.texReset();
    MathJax.typesetPromise();
  }

  if (typeof window.document$ !== "undefined" && window.document$.subscribe) {
    window.document$.subscribe(typeset);
  } else if (document.readyState !== "loading") {
    typeset();
  } else {
    document.addEventListener("DOMContentLoaded", typeset);
  }
})();
