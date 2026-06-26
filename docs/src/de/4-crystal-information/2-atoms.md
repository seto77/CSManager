# Atome

Auf der Registerkarte `Atominfo` werden die Informationen zu den im Kristall enthaltenen Atomen angezeigt und eingestellt. In der oberen Liste wird eine Übersicht der Atome angezeigt; wenn Sie auf ein Atom klicken, werden seine ausführlichen Informationen darunter angezeigt.

!!! warning
    Wenn Sie ein Atom bearbeitet haben, drücken Sie die Schaltfläche `Add` oder `Replace`. Andernfalls werden die Atominformationen nicht in der Liste gespeichert.

## Bedienung der Atomliste

- `Add` — fügt das eingestellte Atom neu zur Liste hinzu.
- `Replace` — ersetzt das aktuell ausgewählte Atom durch das eingestellte Atom.
- `Up` / `Down` — verschiebt die Reihenfolge des ausgewählten Atoms nach oben oder unten.
- `Delete` — löscht das ausgewählte Atom aus der Liste.

## Element und Position

- `Label` — geben Sie die Bezeichnung des Atoms ein.
- `Element` — legt das Element fest.
- `X`, `Y`, `Z` — legt die fraktionellen Koordinaten des Atoms fest. Geben Sie reelle Zahlen von 0 bis 1 ein. Auch Brüche wie 1/2 oder 2/3 können eingegeben werden.
- `Occ` — gibt die Besetzung als reelle Zahl von 0 bis 1 an.

Unter **Origin shift** können Sie die Ursprungsposition mit Voreinstellungstasten oder einem beliebigen Wert verschieben.

## Temperaturfaktor (Debye-Waller-Faktor)

- **Notation** — wählen Sie `U` oder `B`.
- **Model** — wählen Sie isotrop (Isotropy) oder anisotrop (Anisotropy).
- Geben Sie die einzelnen Komponenten des Temperaturfaktors (`B##` oder `U##`) ein.

## Streufaktor (Scattering factor)

Hier stellen Sie die Wertigkeit und die Isotopenzusammensetzung ein, die bei der Berechnung des atomaren Streufaktors verwendet werden.

- **X-ray** — wählen Sie die Wertigkeit, die zur Berechnung des elastischen atomaren Streufaktors für Röntgenstrahlen verwendet wird. Die Parameter beruhen auf *International Tables for Crystallography volume C*.
- **Electron** — wählen Sie die Wertigkeit für den elastischen atomaren Streufaktor für Elektronenstrahlen. Die Parameter beruhen auf Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — wählen Sie die Isotopenzusammensetzung zur Berechnung der elastischen Streulänge für Neutronen. Sie können `Natural isotope abundance` (natürliche Häufigkeit) oder `Custom isotope abundance` (benutzerdefiniert) wählen.
