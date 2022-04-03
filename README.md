# README


# Mars Rover

You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

Requirements

            • You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
            • The rover receives a character array of commands.
            • Implement commands that move the rover forward/backward (f,b).
            • Implement commands that turn the rover left/right (l,r).
            • Implement wrapping from one edge of the grid to another. (planets are spheres after all)
            • Implement obstacle detection before each move to a new square. If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point, aborts the sequence and reports the obstacle.

# Soluzione

WebApi ASP.NET Core
una api con un unico endpoint  POST Set per mandare nel body della request una stringa commandi

_POST Set</br>
{ "commands":"FFLBFFLBFFLBFFLB"}_
Risposta
1 : presenza ostacoli sequenza interrotta
0 : sequenza conclusa

##MainController
L'applicazione ha un unico controller _MainController_
MainController riceve la richiesta nel metodo Set dichiarato con l'attributo [HttpPost],
Dalla request deserializzata è ricavato il parametro da passare al metodo execute del CommandsService.

##Commands Service
Il Commands Service viene opportunamente iniettato nel MainControllor tramite Dependency Injection.
E' molto utile se l'implementazione del set dei comandi del rover dovesse essere estesa , modificata o sostituita senza influire sul codice di controllo del rover stesso.

CommandsService  ha una dependency injection per loggare tramite Ilogger. Attualmente è loggata solo l'occorrenze degli ostacoli.

###comandi
Ho pensato ad una soluzione la cui stringa di comandi fosse la più semplice possibile.I comandi nella stringa possono essere solo quattro:
F per muoversi avanti di 1 posizione
B per muoversi indietro di 1 posizione
L per ruotare a Sinistra
R per ruotare a destra

### inizializzazione comandi
Il set dei comandi è inizializzato con una posizione iniziale x0,y0 ed un limite di percorrenza del rover  xMax, yMax. la griglia delle posizioni è un rettangolo 0,0 xMax, yMax.

### attuazione comandi
L'implementazione di metodi privati nel Command Service gestisce questi quattro comandi prevedendo nel caso dello spostamento sia il controllo del sensore sia il controllo dei limiti della griglia.
Il movimento viene effettuato solo se il sensore rileva che nelle vicinanze non ci sono ostali altrimenti interrompe la sequenza di comandi e ritorna 1 come indicatore di presenza di ostacoli

###wrap della griglia
il superamento della posizione corrente x,y
verso EST oltre xMax setta x a 0
verso OVEST oltre 0 setta x a xMax
verso SUD olre yMax setta y a 0
verso NORS oltre 0 setta y a yMax

### controllo dei sensori
Il controllo dei sensori e semplicemente simulando con un valore random in un range da 1 a 10 che da la possibilità che nella griglia di posizioni ci sia una probabilità del 10% di trovare un ostacolo nel percorso.



## TODO
Init dei comandi da API.
Il comando non è tra quelli previsti.
Reset generale.
Feedback dei sensori sul funzionamento.
Feedback attuatori movimento,

#Casi limite
Non sono stati implementati i casi in cui :
La lista di comandi è troppo lunga.
Eccezzione generica.


#Test
Meglio se il codice fosse stato implementato seguendo dei TDD Test.driven Development.


#Soluzioni alternative
Le possibilità implementative per la movimentazione di un rover sono infinite e ce ne sono sicuramente migliori. I comandi come array di caratteri suggeriva la possibilità di utilizzare ad esempio
F4B6R23L15
che poteva essere implementata con uno split dei singoli comandi
F4 muovere in avanti di 4 posizioni
B6 muovere indietro di 6 posizioni
R23 ruotare a destra di 23 gradi
L15 Ruotare a sinistra di 15 gradi.
Tale soluzione avrebbe necessita di una gestione più articolata del calcolo della posizione finale con coordinate non intere e con superamento dei limiti di griglia anch'esso più articolato.





