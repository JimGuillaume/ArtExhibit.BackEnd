# Overview

Ecriture d'un backend avec des call WebAPI en utilisant la clean architecture(onion) 

# Logique d'ajout d'une Entity

1) Crée une entity               ->        Domain -> Entities
2) Crée les DTOs                 ->        Application -> Dtos
3) Crée l'interface repository   ->    Application -> Interfaces -> Repositorie
4) Crée l'interface service      ->    Application -> Interfaces -> Services                                
5) Implémenter les services      ->    Application -> Services
6) Crée le DbContext             ->    Infrastructure -> Data
7) Implémenter les repositories  ->    Infrastructure -> Repositories
8) Faire la migration            ->    dotnet ef migrations add InitialCreate -o .\Data\Migrations  -p .\.Infrastructure\ -s .\.API\
9) Mettre a jour la DB           ->    dotnet ef database update -p .\.Infrastructure\ -s .\.API\  
10) Ajouter au program.cs        ->    API -> Program.cs
11) Crée les controllers         ->    API -> Controllers

## Utilisation de l'IA
L'IA a été utilisée pour générer les données implémenter dans la méthode OnModelCreating(ModelBuilder builder) dans le fichier [ApplicationDbContext](https://github.com/JimGuillaume/ArtExhibit.BackEnd/blob/master/ArtExhibit.BackEnd.Infrastructure/Data/ApplicationDbContext.cs)
