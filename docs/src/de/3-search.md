# Suche

Im Suchbereich können Sie die geladene Kristalldatenbank anhand verschiedener Kriterien eingrenzen. Aktivieren Sie das Kontrollkästchen des gewünschten Kriteriums, geben Sie einen Wert ein und drücken Sie die Schaltfläche `Suchen` oder die Eingabetaste, um die Suche auszuführen. Mehrere Kriterien können gleichzeitig angegeben werden.

## Suchkriterien

- `Name` — sucht nach dem Namen des Kristalls.
- `Elemente` — durch Drücken der Schaltfläche `Periodensystem` öffnet sich ein separates Fenster, in dem Sie die zu suchenden Elemente auswählen können. Mit jedem Klick wechselt die Schaltfläche eines Elements zwischen den Zuständen (darf enthalten sein / muss enthalten sein / muss ausgeschlossen sein). Mit den Schaltflächen „may or not include“ / „must include“ / „must exclude“ oben im Fenster lässt sich der Zustand aller Elemente auf einmal umschalten.
- `Literatur` — sucht in den Literaturangaben wie Artikeltitel, Zeitschriftenname oder Autorennamen.
- `Kristallsystem` — grenzt nach dem Kristallsystem ein.
- `Gitterkonst.` — gibt die Gitterkonstanten und einen Toleranzbereich an. Einträge, bei denen der Toleranzbereich auf null gesetzt ist, werden ignoriert.
- `d-Wert` — gibt den d-Wert (Netzebenenabstand) einer Kristallebene und einen Toleranzbereich an und sucht Kristalle mit d-Werten innerhalb dieses Bereichs. Wenn `Streufaktor ignorieren` aktiviert ist, wird die Beugungsintensität (der Strukturfaktor) nicht berücksichtigt und auch Kristallebenen, die gegen die Auslöschungsregeln verstoßen, werden in die Suche einbezogen. Ist die Option deaktiviert, wird der Strukturfaktor berücksichtigt und nur die 20 intensitätsstärksten Kristallebenen werden durchsucht.
- `Dichte` — gibt die Dichte und einen Toleranzbereich an.
