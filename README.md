# ![1](https://user-images.githubusercontent.com/85203748/161901959-3c714f32-8559-4580-9826-dd1f5e01c9a8.PNG)
![2](https://user-images.githubusercontent.com/85203748/161901964-7370abe8-2490-4d7b-92cf-2bc5d499ced8.PNG)
Projet : Gestion d’une université

L’application sera constituée par les trois classes suivantes :
Etudiant 
♣ Id_etudiant : entier.
♣ Nom : chaîne de caractères.
♣ Prenom : chaîne de caractères.
♣ Code_departement : chaîne de caractères.
♣ Code_filliere : chaîne de caractères.
Filière 
♣ Nom_filliere : chaîne de caractères.
♣ Code_filliere : chaîne de caractères.
♣ Code_departement : chaîne de caractères.
Departement 
♣ Nom_departement : chaîne de caractères.
♣ Code_departement : chaîne de caractères.

Cette application doit contenir un Menu General :
1- Etudiants
2- Filières
3- Départements
4- Utilisateurs
5- QUITTER
🡺L’application peut avoir plusieurs utilisateurs :
Admin 
Super user
Normal user


🡺Dans 1, l’utilisateur peut ajouter, modifier, supprimer, ou chercher un certain étudiant par son nom. (Accès par toutes les utilisateurs)
Seulement l`admin et les super user : 
Dans 2, l’admin et super user peut ajouter, supprimer, ou chercher une certaine filière par son nom. 
Suppression de certaine filière va supprimer automatiquement toutes les étudiantes de cette filière.
Dans 3, l’admin et super user peut ajouter, supprimer, ou chercher un certain département par son nom. 
Suppression de certain département va supprimer automatiquement toutes les filières, les étudiantes de ce département.
Seulement l`admin:
Dans 4, l’admin peut ajouter, modifier, supprimer, ou chercher un certain utilisateur par son nom. 
NB :
🡪 Impossible de supprimer le compte admin
🡪Impossible de modifier le nom d’utilisateur de compte admin         seulement le mot de passe.
Dans 5, Button pour quitter (retour au formule de login) .(accès par toutes)
