---
title: Kristallinformationen
---

# Kristallinformationen

Im Bereich der Kristallinformationen (dem `Crystal Information`-Steuerelement) werden die Gitterkonstanten, die Symmetrie, die Atompositionen, die Literatur usw. des ausgewählten Kristalls angezeigt und bearbeitet. Sie können auch eine CIF- oder AMC-Datei per Drag & Drop in diesen Bereich ziehen, um einen beliebigen Kristall zu laden.

!!! warning "Änderungen mit `Hinzufügen` / `Ersetzen` bestätigen"
    Wenn Sie einen Kristall ändern, drücken Sie unbedingt die Schaltfläche `Hinzufügen` oder `Ersetzen`. Andernfalls werden die Änderungen nicht in der Kristallliste gespeichert und gehen verloren.

Ganz oben werden allgemeine Informationen wie der Kristallname (`Name`) und die chemische Zusammensetzung (`Formula`) angezeigt; mit `Reset` lassen sich alle Kristallinformationen zurücksetzen. Im unteren Bereich befinden sich Registerkarten zum Einstellen von Symmetrie, Atomen, Literatur usw.

## Registerkarten

- [Grundinformationen](1-basic-information.md) — Gitterkonstanten, Symmetrie, Volumen, Dichte usw. (Registerkarte `Basisinfo`)
- [Atome](2-atoms.md) — Atompositionen, Besetzung, Temperaturfaktoren, Streufaktoren (Registerkarte `Atominfo`)
- [Bindungen und Koordinationspolyeder](3-bonds-polyhedra.md) — Darstellungseinstellungen für Bindungen und Koordinationspolyeder (Registerkarte `Bindungen & Polyeder`)
- [Literatur](4-references.md) — Literaturangaben (Registerkarte `Lit.`)

## Kontextmenü (Rechtsklick)

Wenn Sie mit der rechten Maustaste auf einen leeren Bereich des Steuerelements klicken, stehen folgende Funktionen zur Verfügung.

- `Aus CIF oder AMC importieren...` — importiert eine Kristallstruktur im CIF- oder AMC-Format.
- `Als CIF exportieren` — exportiert den aktuellen Kristall im CIF-Format.
- `Send this crystal to other software` — sendet den ausgewählten Kristall an PDIndexer, ReciPro usw.
- `Symmetrieinformation` — öffnet ein Detailfenster zur Symmetrie (Raumgruppen-Nummer, Laue- und Punktgruppe, Auslöschungsregeln, Wyckoff-Position, geometrische Berechnungen von Kristallebenen und Zonenachsen usw.).
- `Gitterkonstanten zurücksetzen` — setzt die Gitterkonstanten auf die Werte unmittelbar nach dem Laden zurück.
- `In Raumgruppe P1 umwandeln` / `In eine Überstruktur umwandeln` / `Achsen-/Ursprungseinstellung ändern` — führt Umwandlungen der Raumgruppe oder des Gitters durch.
