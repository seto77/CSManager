# Atomi

Nella scheda `Info atomi` si visualizzano e si impostano le informazioni sugli atomi contenuti nel cristallo. Nell'elenco in alto è mostrata la lista degli atomi e, facendo clic su un atomo, le informazioni dettagliate vengono visualizzate nella parte inferiore.

!!! warning
    Dopo aver modificato un atomo, premere il pulsante `Add` o `Replace`. In caso contrario, le informazioni sull'atomo non vengono salvate nell'elenco.

## Operazioni sull'elenco degli atomi

- `Add` — aggiunge come nuova voce all'elenco l'atomo impostato.
- `Replace` — sostituisce con l'atomo impostato l'atomo attualmente selezionato.
- `Up` / `Down` — sposta verso l'alto o verso il basso la posizione dell'atomo selezionato.
- `Delete` — elimina dall'elenco l'atomo selezionato.

## Elemento e posizione

- `Label` — inserisce l'etichetta dell'atomo.
- `Element` — imposta l'elemento.
- `X`, `Y`, `Z` — imposta le coordinate frazionarie dell'atomo. Inserire un numero reale compreso tra 0 e 1. È possibile inserire anche frazioni come 1/2 o 2/3.
- `Occ` — specifica l'occupazione con un numero reale compreso tra 0 e 1.

In **Origin shift** è possibile spostare la posizione dell'origine tramite i pulsanti predefiniti o con un valore arbitrario.

## Fattore termico (Debye-Waller factor)

- **Notation** — selezionare `U` oppure `B`.
- **Model** — selezionare isotropo (Isotropy) o anisotropo (Anisotropy).
- Inserire le varie componenti del fattore termico (`B##` oppure `U##`).

## Fattore di diffusione (Scattering factor)

Imposta la valenza e la composizione isotopica utilizzate nel calcolo del fattore di diffusione atomico.

- **X-ray** — seleziona la valenza utilizzata nel calcolo del fattore di diffusione atomico elastico per i raggi X. I parametri si basano su *International Tables for Crystallography volume C*.
- **Electron** — seleziona la valenza per il fattore di diffusione atomico elastico per i fasci di elettroni. I parametri si basano su Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — seleziona la composizione isotopica per il calcolo della lunghezza di diffusione elastica dei neutroni. È possibile scegliere `Natural isotope abundance` (abbondanza isotopica naturale) oppure `Custom isotope abundance` (impostazione personalizzata).
