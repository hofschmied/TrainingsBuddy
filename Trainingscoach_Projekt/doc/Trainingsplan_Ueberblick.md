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
| - Speichern()
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