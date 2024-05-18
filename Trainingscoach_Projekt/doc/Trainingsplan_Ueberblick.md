# Trainingsplaner TODO-Liste:

## Must-Haves;

### Menüfenster:
- Hauptfenster bei dem man neue Task erstellen kann, Task starten, Task löschen kann, Task Laden, Speicher kann
- Im Hauptfenster wird per erstellter Task die Grund-Trainingseinheit vom Benutzer angezeigt
###

### Main Programm Fenster
- Hier wird das "richtige" Programm ausgeführt. Der User plant die genaue Reihenfolge für sein (im Menüfenster ausgewähltes) Armtraining ein.
- Z.B: 30 Sets Liegestütze in 10 Minuten, die nächsten 10 Minuten werden gehantelt, dannach ist 5 Minuten Pause. Die Trainingseinheiten erfolgen per Timer.
- Zu der Trainingseinheit wird dann auch ein passendes Bild angezeigt
- Login Datei
- Fehlererkennung

## Nice-To-Haves
- Skip Button bei Pause 
- Punktesystem und Achievements
- Random Trainingsmodus (der User kriegt zufällige Trainingseinheiten in einer bestimmten Zeit zu erfüllen, ohne sein Training voarb planen zu müssen)
- Trainingsplan in ein Wochenplan-System integrieren
- Im Hauptfenster wird per Radio-Button ausgewählt, ob die Trainingseinheit per Timer oder ohne erfolgen (manuell vom User) soll
- In Datenbanken speichern (wenn nicht muss, dann Nice-To-Haves oder Not-To-Haves)
- Timer spielt Töne ab
- Falls im Menüfenster "ohne Timer" augewählt wurde, plant der User zwar die Trainingseinheiten genau ein, aber hat keine bestimmte vorgegebene Zeit. Der User kann die nächste Trainingseinheit per "Leertaste" Klick starten.
- Schwieriegkeit der Übung angeben (mehr Punkte)

# Not-To-Haves
- Komplexe Benutzeroberflächen
- Anmelde System
- Sehr gutes Design

# Klassendiagramm

 Grundfenster
------------------|
| - <get;set> Trainingsname: string|
| - <get;set> Grundeinheit: liste|
------------------|
Grundfenster(Trainingsname, Grundeinheit)
Grundfenster(Grundeinheit)
------------------|
| - neueGrundEinheitHinzufuegen()
| -     
| - Laden()

Ausführung
------------------|
| - <get;set> spezifizierteEinheit: liste|
| - <get;set> BeschreibungSpezifizierteEinheit: string|
| - <get;> Startzeit: double|
| - <get;> Endzeit: double|
| - <get;> Timer: timer|
| - <get;> Pause: const|
------------------|
Ausführung(Startzeit, Endzeit, Timer, Pause)
------------------|
| - neueSpezifischeEinheitHinzufuegen()
| - ErstelleTimer()
| - SetzerTimerVonBis()
| - SetzePausen()
| - ResetTimer()
| - Serialize()
| - Deserialize()

-----------------------------
# TageBuch:

## Tag 1 (1.Mai-6.Mai 2024):
Projekt wurde erstellt und beide Teammitglieder haben nun über Git Zugriff auf das Projekt

## Tag 2 (7.Mai 2024)
Die Überblick und Planung zu unserem Projekt wurde bearbeitet. Das Startfenster wurde erstellt. Start mit dem Design des Startfensters

## Tag 3 (8.Mai 2024)
Das Design des Startfenster wurde bearbeitet. Auch die Funktionalität wurde eingeführt. Z.B: Hinzufügen der Buttons. 
Es wurde zudem ein neues Fenster für das Auswählen der Grund-Trainingseinheiten erstellt.
Die ausgewählten Daten werden nun auch in die ListBox des Start-Windows eingetragen. Design für das Grund-Trainingseinheit-Auswahl Fenster wurde erstellt

## Tag 4 (9.Mai 2024)
Die Daten der Fenster wurden mit Klassen-Objekte verknüpft.

## Hier gab es dann eine Pause da ich (Nathan) in London war.

## Tag 5 (12.Mai 2024)
Neues Fenster für die spezifische Trainingseinheit wurde erstellt und bearbeitet

## Tag 6 (14.Mai 2024)
Es wurde für jede Grund- Trainingseinheit ein Fenster erstellt, dass auf die Wünsche des Benutzers eingeht.

## Tag 7 (15.Mai 2024)
Die spezifischen Einheiten wurden in das Grund- Trainingseinheiten Fenster implementiert.

## Tag 8 (19.Mai 2024)
spezifische Einheiten für das Bauch-Fenster wurden hinzugefügt
Erster Info Button wurde geadded