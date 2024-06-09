# Trainingsplaner TODO-Liste:

## Must-Haves;

### Menüfenster:
- Hauptfenster bei dem man neue Task erstellen kann, Task starten, Task löschen kann, Task Laden, Speicher kann
- Im Hauptfenster wird per erstellter Task die Grund-Trainingseinheit vom Benutzer angezeigt
-  Z.B: 30 Sets Liegestütze pro Set 3 Minuten
-  - 1 Set Hanteln pro Set 10 Minuten

### Auswahl Fenster
- Sobald die richtige Grundeinheit angegeben wurde, werden dir zu der jeweiligen Grundeinheit Übungen vorgeschlagen. Diese kannst du dann hinzufügen und per Übung sagen
  wie lange sie pro Set gehen soll und wie viel Sets

### Main Programm Fenster
- Hier wird das "richtige" Programm ausgeführt. Die genau eingeplante Reihenfolge des Auswahl Fenster wird hier abgespielt.
- Z.B: 30 Sets Liegestütze pro Set 3 Minuten die nächsten 10 Minuten werden 1 Set gehantelt, dannach ist 2 Minuten Pause. Die Trainingseinheiten erfolgen per Timer.
- Logging Datei

## Nice-To-Haves
- Skip Button bei Pause 
- übersichtliches Menü Fenster
- passende Bilder zu den jeweiligen Übungen
- beschreibung zu den jeweiligen Übungen
- visualisierter Timer
- Statistik
- Aufgabensystem (Nutzer muss Aufgaben erledigen)
- Timer spielt Töne ab
- zwischen den Sets befindet sich automatisch eine Verschnaufpause (15 Sekunden)

## Not-To-Haves
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

## Eintrag 1 (1.Mai-6.Mai 2024):
- Projekt wurde erstellt und beide Teammitglieder haben nun über Git Zugriff auf das Projekt

## Eintrag 2 (7.Mai 2024)
- Die Überblick und Planung zu unserem Projekt wurde bearbeitet. Das Startfenster wurde erstellt. Start mit dem Design des Startfensters

-## Eintrag 3 (8.Mai 2024)
- Das Design des Startfenster wurde bearbeitet. Auch die Funktionalität wurde eingeführt. Z.B: Hinzufügen der Buttons. 
- Es wurde zudem ein neues Fenster für das Auswählen der Grund-Trainingseinheiten erstellt.
- Die ausgewählten Daten werden nun auch in die ListBox des Start-Windows eingetragen. Design für das Grund-Trainingseinheit-Auswahl Fenster wurde erstellt

## Eintrag 4 (9.Mai 2024)
- Die Daten der Fenster wurden mit Klassen-Objekte verknüpft.


## Eintrag 5 (12.Mai 2024)
- Neues Fenster für die spezifische Trainingseinheit wurde erstellt und bearbeitet

## Eintrag 6 (14.Mai 2024)
- Es wurde für jede Grund- Trainingseinheit ein Fenster erstellt, dass auf die Wünsche des Benutzers eingeht.

## Eintrag 7 (15.Mai 2024)
- Die spezifischen Einheiten wurden in das Grund- Trainingseinheiten Fenster implementiert.

## Eintrag 8 (19.Mai 2024)
- spezifische Einheiten für das Bauch-Fenster wurden hinzugefügt
- Erster Info Button wurde geadded

## Eintrag 9 (19.Mai 2024)
- das Design der Einheiten-Fenster wurde komplett geändert/umstrukturiert

## Eintrag 10 (20.Mai 2024)
- Die entsprechenden Methoden für das Cardio Fenster wurden hinzugefügt und die Bilder als Reccource definiert

## Eintrag 11 (22.Mai 2024)
- Infos für jedes Bauch und Brust Training hinzugefügt
- Infos für die Einheiten des GanzKörper Trainings wurden hinzugefügt
- neues Fenster für die Benutzerdaten wurde hinzugefügt und funktioniert auf die ersten Button drücke.
- Datenfenster beim addButton im Armfenster hinzugefügt

## Eintrag 12 (23.Mai 2024)
- Die ausgewählte Übung wird jetzt formatiert in die ListBox eingetragen. Funktioniert für das Fenster Ganzkörper-Training, und muss somit noch für die anderen       implementiert werden.

## Eintrag 13 (24.Mai 2024)
- Datenfenster beim addButton im RueckenFensterhinzugefügt und beim BeinFenster es verbessert
- DatenFenster beim addButton in alle anderen Fenster erstellt, listbox und cancel bei allen anderen Fenster gemacht

## Eintrag 14 (25.Mai 2024)
- Fehlermeldungen werden abgefangen. Wenn Benutzer nichts eingibt aber fortfahren will, oder wenn die Textboxen ungültige Werte enthalten
- Fenster für Timer-Hauptprogramm + passende Klasse dafür erstellt
- HauptFensterTimer designed

## Eintrag 15 (26.Mai 2024)
- LöschenButton für die Listbox in alle TrainingsEinheitenFenster gemacht
- Design des Hauptprogrammes überarbeitet
- Erste Methoden für Hautpprogramm geschrieben

## Eintrag 17 (27.Mai 2024)
- Timer Design gestartet
- Timer wird geupdatet

## Eintrag 18 (29.Mai 2024)
- Die Daten aus der Liste werden jetzt richtig in die TextBloöcke eingetragen mit Index 0. sprich wenn index 0 gelöscht wird wird der nächste string aus der liste index 0
- Timer gezeichnet. Tickt Richtig nach den Angaben von dem User

## Eintrag 19 (1.Juni 2024)
- Timer geht auch mit double Zahlen jetzt ud wandelt richtig um
- Timer updated sich und reset jetzt je nach Sets und spielt nach jedem beendigten Set einen Sound ab. Wenn keine sets mehr übrig sind --> 5 Minuten Pause
- Musik eingeführt
- Richtiger Pfad für die Sound Dateien angegeben für andere Nutzer. Wenn Fenster geschlossen Sound stoppt Funktion eingebaut

## Eintrag 20 (2.Juni 2024)
- Kleine Verschnaufpause nach jedem Set eingeführt. Wird richtig geupdated
- Design verändert MainWindow
- Spotify Button sendet dich auf Webseite von Spotify Playlist
- Timer Grafisch umstrukturiert und Deisng von GrundTrainingsFensterAuswahl geändert
- Aktualisieren des Timer gestartet

## Eintrag 21 (4. Juni 2024)
- Timer aktualisiert sich nun mit de nächsten Übung, sobald die eine fertig ist
- Statistik hinzugefügt, muss aber noch bearbeitet werden.

## Eintrag 22 (5.Juni 2024)
- Fenster für Training beendet ersetllt und funktioniert
- Timer funktioniert nun für jede Trainingseinheit
- die dauer von der statistik richtig hinschreiben
- Leere Listen erstellt für jedes Fenster --> für die Speicherstände

## Eintrag 23 (6.Juni 2024)
- Kampf mit dem Bug

## Eintrag 24 (7.Juni 2024)
- Die Daten der ListBox werden jetzt richtig gespeichert wenn Fenster geschlossen wird
- Speichern/Laden angefangen
- Statistik soll sich mit den sets anpassen, funktioniert so halb

## Eintrag 25 (8.Juni 2024)
- Quest Fenster wurden erstellt und die dazugehörigen Aufgaben
- Statisktik zeichnet jetzt auch mit mehreren sets richtig
- Datenfenster fertig Designt
- Laden Speichern klappt nun perfekt
- Statistik geändert sollte bald klappen
- alle Buttons einheitlich designt.
- Übungen werden nun richtig in die "erledigte Uebungen" Listebox geadded und hab so noch bisschen gespielt an den Aufgaben etc

## Eintrag 26 (9.Juni 2024)
- Alles geloggt
- Quests werden nun vom Benutzer abgehackt wenn er sie erledigt hat und sie werden gespeichert und geladen
- Bug gefixt dass Programm beim Laden Speichern der erldigten Quests abstürzt

# Probleme
- Wir hatten vor allem zuerst Probleme dass es den Timer richtig mit den nächsten Übungen aktualisiert und dann richtig tickt
  - hat länger gedauert
  - 
- Unser größtes Problem hatten wir aber mit den Speicherständen, dass es die Daten in der ListBox in jedem einzelnen Fenster richtig speichert und dann unserer Session zuordnet
  - hat 3 Tage gebraucht mit Hilfe zu fixen
  
# Fazit
- Wir sind im großen und ganzen sehr zufrieden mit unserem Projekt, da es im Grunde gut funktioniert und auch brauchbar ist. Wir haben vor allem viel neues dazugelernt
  und der Spaßfaktor war natürlich auch dabei.