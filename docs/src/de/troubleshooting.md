# Fehlerbehebung

Hier sind häufige Probleme und ihre Lösungen zusammengefasst.

- **Programm startet nicht / .NET-Runtime wird nicht gefunden** — Für den Betrieb von CSManager ist **.NET Desktop Runtime 8** oder höher erforderlich. Falls sie nicht installiert ist, beziehen Sie sie bitte von der Downloadseite von Microsoft.
- **COD lässt sich nicht laden** — `COD-Datenbank laden (### Kristalle)` lädt beim ersten Mal eine große Datei (über 800 MB) aus dem Internet herunter. Prüfen Sie Ihre Netzwerkverbindung und den freien Speicherplatz und versuchen Sie es nach einiger Zeit erneut.
- **Datenbankdatei lässt sich nicht öffnen** — Prüfen Sie, ob die `*.cdb3`-Datei beschädigt, verschoben oder mit einer anderen Version gespeichert wurde. Wenn Sie AMCSD / COD unverändert verwenden, können Sie sie über `AMCSD-Datenbank laden (### Kristalle)` / `COD-Datenbank laden (### Kristalle)` erneut laden.
- **Langsame Leistung bei großen Datenbanken** — Bei großen Datenbanken wie COD können Suche und Laden längere Zeit in Anspruch nehmen. Grenzen Sie die Daten mit den benötigten Kriterien ein, bevor Sie weitere Aktionen durchführen.
- **Keine Zusammenarbeit mit PDIndexer / ReciPro möglich** — Prüfen Sie, ob das Zielprogramm gestartet ist. Die automatische Übertragung bei der Auswahl erfolgt über die Zwischenablage (siehe [Zusammenarbeit mit anderer Software](6-interoperation.md)).

Probleme, die hier nicht aufgeführt sind, melden Sie bitte über das [Issue](https://github.com/seto77/CSManager/issues) auf GitHub.
