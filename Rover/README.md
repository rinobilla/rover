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
resposnse
1 : presenza ostacoli sequenza interrotta
0 : sequenza conclusa

L'applicazione ha un unico controllor _MainController_</br>
MainController riceve la richiesta nel metodo Set dichiarato con l'attributo [HttpPost],
Dalla request deserializzata è ricavato il parametro da passare al metodo execute del CommandsService opportunamento inietaato nel
MainControllor tramite Dependency Injection. 

Molto utile se l'implementazione devisa per i set di comandi dovesse essere estesa , modificata o sostituita

Ho pensato ad una soluzione la cui stringa di comandi fosse la più semplice possinile per cui i comandi nella stringa possono essere solo quattro


F per muoversi avanti di 1 posizione<br>
B per muoversi indietro di 1 posizione<br>
L per ruotare a Sinistra<br>
R per ruotare a destra<br>

L'implmetazione di metodi privati nel Command Service gestisce questi quattro comandi prevedendo nel caso dello spostamento sia il controllo del sensore sia il controllo dei limiti della Mappa

Il movimento viene effettuato solo se il sensore rileva che nelle vicinanze non ci sono ostali altrimenti interrompe la sequenza di comandi e ritorna 1 come indicatore di presenza di ostacoli

Il controllo dei sensori e semplicemente simulando con un valore random in un range da 1 a 10 che da la possibiltà che nella griglia di posizioni ci sia una probabilitò del 10% di trovare un ostacolo nel percorso.

Commands ha una dependency injection per loggare tramite Ilogger. Attualmnente è loggato l'occorrenze degli ostacoli




