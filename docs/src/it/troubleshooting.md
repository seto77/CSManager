# Risoluzione dei problemi

Di seguito sono riassunti i problemi più comuni e le relative soluzioni.

Il requisito di runtime seguente si applica alle build di questo albero sorgente (.NET 11). Per le versioni pubblicate, seguire il requisito indicato per quella versione. Gli archivi ZIP portabili includono il runtime.

- **Impossibile avviare / runtime .NET non trovato** — il funzionamento di CSManager richiede **.NET Desktop Runtime 11**. Se non è installato, scaricarlo dalla pagina di distribuzione di Microsoft.
- **Il caricamento di COD non riesce** — `Leggi database COD (### cristalli)` scarica da Internet, al primo utilizzo, un file di grandi dimensioni (oltre 800 MB). Verificare la connessione di rete e lo spazio libero su disco, quindi riprovare dopo qualche tempo.
- **Impossibile aprire il file di database** — verificare che il file `*.cdb3` non sia danneggiato, spostato o salvato con una versione diversa. Se si utilizzano direttamente AMCSD / COD, è possibile ricaricarli da `Leggi database AMCSD (### cristalli)` / `Leggi database COD (### cristalli)`.
- **Funzionamento lento con database di grandi dimensioni** — con database di grandi dimensioni come COD, la ricerca e il caricamento possono richiedere tempo. Filtrare con i criteri necessari prima di procedere.
- **Impossibile interoperare con PDIndexer / ReciPro** — verificare che il software di destinazione sia in esecuzione. Il trasferimento automatico alla selezione avviene tramite gli appunti (vedere [Interoperabilità con altri software](6-interoperation.md)).

Per problemi non elencati qui, segnalarli aprendo una [Issue](https://github.com/seto77/CSManager/issues) su GitHub.
