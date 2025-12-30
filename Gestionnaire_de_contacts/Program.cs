using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Gestionnaire_de_contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            string choix = "0";
            List<Contact> liste_contact = new();
            string chemin = Path.Combine(Environment.CurrentDirectory, "contacts.txt");
            if (!File.Exists(chemin))
            {

                File.WriteAllText(chemin, string.Empty);
            }
            string contenu = File.ReadAllText(chemin);
            while (choix != "4")
            {
                try
                {
                    Console.WriteLine("Bienvenue dans le gestionnaire de contacts");
                    Console.WriteLine("1 - Voir les contacts");
                    Console.WriteLine("2 - Ajouter un contact");
                    Console.WriteLine("3 - Supprimer un contact");
                    Console.WriteLine("4 - Quitter");
                    choix = Console.ReadLine();
                    Console.Clear();
                    switch (choix)
                    {
                        case "1":
                            contenu = File.ReadAllText(chemin);
                            if (contenu.Length > 0)
                            {
                                Console.WriteLine(contenu);
                            } else
                            {
                                Console.WriteLine("Il n'y a pas de contacts à afficher.");
                            }
                            break;
                        case "2":
                            Contact contact = new Contact();
                            string prenom, nom, numero;
                            Console.WriteLine("Veuillez entrer un prenom : ");
                            prenom = Console.ReadLine();
                            while (!contact.isPrenomValid(prenom))
                            {
                                Console.WriteLine("Erreur - Veuillez entrer un prenom valide : ");
                                prenom = Console.ReadLine();
                            }
                            contact.setPrenom(prenom);
                            Console.WriteLine("Veuillez entrer un nom : ");
                            nom = Console.ReadLine();
                            while (!contact.isNomValid(nom))
                            {
                                Console.WriteLine("Erreur - Veuillez entrer un nom valide : ");
                                nom = Console.ReadLine();
                            }
                            contact.setNom(nom);
                            Console.WriteLine("Veuillez entrer un numéro de téléphone : ");
                            numero = Console.ReadLine();
                            while (!contact.isNumeroValid(numero))
                            {
                                Console.WriteLine("Erreur - Veuillez entrer un numéro de téléphone valide : ");
                                numero = Console.ReadLine();
                            }
                            contact.setNumero(numero);
                            Console.WriteLine("Contact Ajouté");
                            liste_contact.Add(contact);
                            foreach (var cont in liste_contact)
                            {
                                File.AppendAllText(chemin, (File.ReadAllLines(chemin).Length + 1) + " " + cont.getAll() + "\n");
                            }
                            liste_contact.Clear();
                            break;
                        case "3":
                            int numero_a_supprimer = 0;
                            Console.WriteLine(contenu);
                            var lignes = File.ReadAllLines(chemin).ToList();
                            if (lignes.Count > 0)
                            {
                                bool succes = false;
                                string s = "";
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Quel contact souhaitez-vous supprimer ? : ");
                                        s = Console.ReadLine();
                                        numero_a_supprimer = int.Parse(s);

                                        while (numero_a_supprimer > lignes.Count)
                                        {
                                            Console.WriteLine("Erreur - Quel contact souhaitez-vous supprimer ? : ");
                                            s = Console.ReadLine();
                                            numero_a_supprimer = int.Parse(s);
                                        }
                                        succes = true;
                                    }
                                    catch (Exception err)
                                    {
                                        Console.WriteLine("Erreur - Veuillez entrer un nombre");
                                    }

                                } while (!succes);
                                lignes.RemoveAt(numero_a_supprimer - 1);
                                File.WriteAllLines(chemin, lignes);
                                string[] arr_lignes = File.ReadAllLines(chemin);
                                for (int i = 0; i < arr_lignes.Length; i++)
                                {
                                    arr_lignes[i] = arr_lignes[i].Substring(1);
                                    arr_lignes[i] = (i + 1).ToString() + arr_lignes[i];
                                }
                                File.WriteAllLines(chemin, arr_lignes);
                                Console.WriteLine("Ligne supprimée");
                            } else
                            {
                                Console.WriteLine("Il n'y a pas de contacts à supprimer.");
                            }
                            break;

                        case "4":
                            Console.WriteLine("Merci d'avoir utilisé le Gestionnaire de contacts");
                            break;
                        default:
                            Console.WriteLine("Veuillez choisir une option valide.");
                            break;

                    }

                    Console.WriteLine("Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception erreur)
                {
                    Console.WriteLine("Une Erreur est survenue.");
                }
            }
        }

    }
}
