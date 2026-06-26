---
title: Informazioni sul cristallo
---

# Informazioni sul cristallo

Nell'area delle informazioni sul cristallo (controllo `Crystal Information`) vengono visualizzati e modificati i parametri di cella, la simmetria, le posizioni atomiche, i riferimenti bibliografici e altro del cristallo selezionato. È inoltre possibile caricare un cristallo qualsiasi trascinando un file CIF o AMC in quest'area.

!!! warning "Confermare le modifiche con `Aggiungi` / `Sostituisci`"
    Dopo aver apportato modifiche a un cristallo, premere sempre il pulsante `Aggiungi` o `Sostituisci`. In caso contrario, le modifiche non vengono salvate nell'elenco dei cristalli e vanno perse.

Nella parte superiore sono visualizzate informazioni comuni come il nome del cristallo (`Name`) e la composizione chimica (`Formula`); con `Reset` è possibile reimpostare tutte le informazioni del cristallo. Nella parte inferiore sono disposte le schede per configurare simmetria, atomi, riferimenti bibliografici e altro.

## Schede

- [Informazioni di base](1-basic-information.md) — parametri di cella, simmetria, volume, densità e altro (scheda `Info base`)
- [Atomi](2-atoms.md) — posizioni atomiche, occupazione, fattori termici e fattori di diffusione (scheda `Info atomi`)
- [Legami e poliedri di coordinazione](3-bonds-polyhedra.md) — impostazioni di rappresentazione di legami e poliedri di coordinazione (scheda `Legami & Poliedri`)
- [Riferimenti bibliografici](4-references.md) — informazioni sui riferimenti citati (scheda `Rif.`)

## Menu contestuale

Facendo clic con il tasto destro su una parte vuota del controllo, è possibile eseguire le seguenti operazioni.

- `Importa da CIF o AMC...` — importa una struttura cristallina in formato CIF / AMC.
- `Esporta in CIF` — esporta il cristallo corrente in formato CIF.
- `Send this crystal to other software` — invia il cristallo selezionato a PDIndexer, ReciPro o altri software.
- `Informazioni sulla simmetria` — apre una finestra dettagliata relativa alla simmetria (numero d'ordine del gruppo spaziale, gruppo di Laue e gruppo puntuale, regole di apparizione, posizioni di Wyckoff, calcoli geometrici di piani cristallini e assi di zona, ecc.).
- `Ripristina i parametri di cella` — riporta i parametri di cella ai valori immediatamente successivi al caricamento.
- `Converti nel gruppo spaziale P1` / `Converti in una superstruttura` / `Cambia impostazione assi/origine` — esegue conversioni del gruppo spaziale o del reticolo.
