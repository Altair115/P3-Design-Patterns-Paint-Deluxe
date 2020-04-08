# P3-Design-Patterns-Paint-Deluxe
P3 Design patterns Project


# Grafische editor
Met een grafische editor kunnen ellipsen en rechthoeken getekend worden. De figuren moeten met de muis getekend
kunnen worden en met de muis geselecteerd kunnen worden. Een of meer geselecteerde figuren moeten tot een groep
gemaakt kunnen worden. Groepen gedragen zich verder als basisfiguren. Wat inhoudt dat binnen groepen weer groepen
kunnen zitten, waarbinnen weer groepen zitten etc.. (zonder beperking aan de nesting). Verder moeten figuren (en dus
ook groepen) verplaatst kunnen worden en van grootte veranderd kunnen worden. Plaatjes moeten ook op schijf kunnen
worden opgeslagen en weer kunnen worden teruggelezen.
In deze opgave moet een grafische editor gemaakt worden met gebruikmaking van design patterns. Dit moet in
verschillende stappen gebeuren, waarbij de al gemaakte code vaak van structuur veranderd moet worden (refactoring).

# Stap 1: eenvoudig tekenprogramma
- Maak een eerste versie van de grafische editor die ellipsen en rechthoeken kan tekenen, selecteren, verplaatsen en van grootte veranderen.
- Groepen, bijschriften en file operaties hoeven nu nog niet.

# Stap 2: command pattern
- Voeg file IO toe (volgens de grammatica die verderop uitgelegd wordt).
- Zorg ervoor dat alle acties die een gebruiker kan uitvoeren, via command-objecten worden gedaan.
- Voeg de mogelijkheid toe om acties ongedaan te maken (onbeperkte undo en redo).

# Stap 3: composite pattern
- Voeg groepen toe volgens het composite pattern.
- Pas ook de file IO aan.
- Bijschriften hoeven nu nog niet.

# Stap 4: visitor pattern
- Implementeer een visitor klasse voor de figuren.
- Verplaatsen, resizen en schrijven naar file moeten door subklassen van deze visitor uitgevoerd worden. 
- Refactor het programma.

# Stap 5: strategy pattern en singleton pattern
- Het verschil tussen een ellips en een rechthoek is eigenlijk alleen de manier van tekenen en hun naam.
- We kunnen ze dus wel samennemen tot een klasse "basisfiguur".
- Een basisfiguur bevat coordinaten en een pointer naar een strategy object (zijn delegate).
- De delegate kan tekenen en heeft een toString methode.
- Er zijn maar 2 delegates nodig: voor een ellips en voor een rechthoek. Dit kunnen singleton objecten zijn.
- Refactor het programma

# Stap 6: decorator pattern
- Nu moeten er bijschriften bij de figuren geplaatst kunnen worden (soms ernaast, soms erboven, soms eronder).
- Er kunnen meerdere bijschriften bij een figuur staan en ook groepen kunnen bijschriften hebben.
- Het decorator pattern is hiervoor zeer geschikt.
- Pas ook de file IO aan.
- Refactor het programma.

# Beoordeling:
de opgave wordt beoordeeld aan de hand van de volgende criteria:
- elke stap moet worden gedemonstreerd en besproken met de begeleidende docent
- bij elke stap moet de broncode en een ontwerpdocument worden ingeleverd
- broncode is voorzien van voldoende commentaar
- een ontwerpdocument bevat een UML-beschrijving in de vorm van begeleidende tekst, klassendiagrammen, toestandsdiagrammen en tijdsvolgordediagrammen (voor zover van toepassing)

NB: De ontwerpdocumenten vormen tezamen het rapport bij de eindopdracht. 

# Grammatica:
```
file = group
group = "group" count {figure}
figure = group | rectangle | ellipse | ornament
rectangle = "rectangle" left top width height
ellipse = "ellipse" left top width height
ornament = "ornament" position string figure
position = "top" | "bottom" | "left" | "right"
count, left, top, width, height = int
```
- Hierbij betekent { } dat iets 0 of meer keer kan voorkomen.
- En [ ] dat iets 0 of 1 keer kan voorkomen.
- En " " betekent dat de tekst binnen de quotes letterlijk voorkomt.



# Voorbeeld:
```
 group 2
  ornament top "rondje"
   ellipse 100 100 20 50
   group 3
    rectangle 10 20 100 100
    ornament top "group"
    ornament bottom "ellipses"
    group 2
      ellipse 50 150 20 50
      ellipse 70 150 20 50
    rectangle 100 100 10 10
```    
 
- Dit geeft een file aan die bestaat uit een groep van 2 figuren.
- De eerste figuur is een ellips met left=100, top=100, width=20, height=50 met een bijschrift "rondje" erboven.
- De tweede figuur is een groep van 3 figuren: een rechthoek, een groep van 2 ellipsen en weer een rechthoek.
- De groep van 2 ellipsen heeft zowel een bijschrift aan de bovenkant als een bijschrift aan de onderkant.

Een ornament hoort altijd bij de eerstvolgende figuur en er kunnen meerdere ornamenten bij een figuur horen.
De volgorde van figuren binnen een groep is in principe vrij.

Het inspringen is verplicht en gebeurt alleen bij groepen, dus niet bij een ornament.
Verder moet tussen woorden op een regel 1 spatie staan.
De verschillende elementen group, rectangle, ellipse en ornament moeten elk op een afzonderlijke regel staan. 
