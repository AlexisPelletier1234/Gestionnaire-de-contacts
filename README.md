# Gestionnaire de contacts (Console C#)

Projet réalisé pour me remettre dans le C# : revoir la structure d’un projet .NET, la manipulation de fichiers et les interactions utilisateur en console.

## Description
Ce gestionnaire de contacts simple permet de :

Lister les contacts enregistrés dans un fichier texte (contacts.txt).
Ajouter un contact (avec validation du prénom, du nom et du numéro).
Supprimer un contact par son numéro de ligne (réindexation automatique).

Le projet utilise un fichier texte local pour la persistance, et une classe Contact (à ajouter) pour encapsuler les validations et le formatage des données.

## Fonctionnement
Menu principal

1 – Voir les contacts
2 – Ajouter un contact
3 – Supprimer un contact
4 – Quitter

Format du fichier contacts.txt
Chaque ligne représente un contact dans le format :
{index} {Prenom} {Nom} - {Numero}

Exemple :
1 John Doe - 514-555-1234
2 Marie Curie - 438-555-9876


Lors d’une suppression, les lignes sont réécrites et les index sont recalculés pour rester consécutifs.


## Technologies

Langage : C#
Framework : .NET (ex. net6.0 ou net8.0)
Type de projet : Application console
Fichier de persistance : contacts.txt (dans Environment.CurrentDirectory)


## Prérequis

.NET SDK (version au choix, ex. net6.0 / net8.0)
Un IDE : Visual Studio ou VS Code + extension C#


## Installation & Exécution


Cloner le dépôt :
Shellgit clone https://github.com/<ton-utilisateur>/<ton-repo>.gitcd <ton-repo>Afficher plus de lignes


Créer un fichier contacts.txt dans le dossier d’exécution (peut être vide).


Construire et lancer :
Shelldotnet builddotnet runAfficher plus de lignes



## Structure (suggestion)
Gestionnaire_de_contacts/
├─ Program.cs
├─ Contact.cs            # classe à ajouter (validation + formatage)
└─ contacts.txt          # persistance des contacts (texte)

Contact.cs (à créer)
La classe Contact doit fournir par exemple :

setPrenom(string), setNom(string), setNumero(string)
isPrenomValid(string), isNomValid(string), isNumeroValid(string)
getAll() → retourne {Prenom} {Nom} - {Numero}


## Validations & gestion d’erreurs

Les entrées utilisateur sont validées via la classe Contact.
La suppression exige un numéro valide (boucle avec int.Parse et contrôle des bornes).
try/catch autour de la boucle principale pour capturer les erreurs imprévues.
Le fichier est rechargé avant affichage et réécrit après suppression pour maintenir la numérotation.


## Notes de conception

Environment.CurrentDirectory est utilisé pour localiser contacts.txt au runtime.
L’ajout écrit les nouvelles lignes via File.AppendAllText et numérote en fonction du nombre de lignes existantes (File.ReadAllLines(chemin).Length + 1).
La suppression suit :

Lecture des lignes → List<string>
RemoveAt(index - 1)
Réécriture et réindexation des lignes avec Substring(1) + réinsertion de l’index.




## Améliorations possibles

Centraliser les I/O (méthodes pour lire/écrire/afficher) au lieu d’éparpiller File.ReadAllText/ReadAllLines.
Utiliser JSON (System.Text.Json) pour une persistance structurée, plutôt que texte libre.
Ajouter des tests unitaires (ex. xUnit) pour les validations de Contact.
Modifier un contact existant (nouvelle option de menu).
Normaliser les numéros (ex. E.164) et/ou valider via Regex.
Améliorer l’UX console (couleurs, colonnes, pagination).
Gérer les erreurs spécifiques (ex. FileNotFoundException, FormatException) avec messages dédiés.


## Objectif personnel
Ce projet est un exercice de reprise du C#: remise à niveau sur la syntaxe, la POO, les I/O avec fichiers et la gestion des erreurs. Le but est d’évoluer vers des projets plus complets par la suite.
