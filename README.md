# Overview

Ecriture d'un backend avec des call WebAPI en utilisant la clean architecture(onion) 
# Structure du projet
```
📦 
├─ .gitattributes
├─ .gitignore
├─ ArtExhibit.BackEnd.API
│  ├─ ArtExhibit.BackEnd.API.csproj
│  ├─ ArtExhibit.BackEnd.API.http
│  ├─ Controllers
│  │  ├─ CategoryController.cs
│  │  ├─ InvoiceController.cs
│  │  ├─ ItemController.cs
│  │  ├─ ItemReviewController.cs
│  │  ├─ OrderController.cs
│  │  ├─ PaymentController.cs
│  │  ├─ ReportController.cs
│  │  ├─ SaleController.cs
│  │  ├─ ShipmentController.cs
│  │  ├─ SubmissionController.cs
│  │  ├─ UserController.cs
│  │  └─ UserTypeController.cs
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ appsettings.Development.json
│  └─ appsettings.json
├─ ArtExhibit.BackEnd.Application
│  ├─ ArtExhibit.BackEnd.Application.csproj
│  ├─ DTOs
│  │  ├─ CategoryDTO.cs
│  │  ├─ CreateCategoryDTO.cs
│  │  ├─ CreateInvoiceDTO.cs
│  │  ├─ CreateItemDTO.cs
│  │  ├─ CreateItemReviewDTO.cs
│  │  ├─ CreateOrderDTO.cs
│  │  ├─ CreatePaymentDTO.cs
│  │  ├─ CreateReportDTO.cs
│  │  ├─ CreateSaleDTO.cs
│  │  ├─ CreateShipmentDTO.cs
│  │  ├─ CreateSubmissionDTO.cs
│  │  ├─ CreateUserTypeDTO.cs
│  │  ├─ InvoiceDTO.cs
│  │  ├─ ItemDTO.cs
│  │  ├─ ItemReviewDTO.cs
│  │  ├─ OrderDTO.cs
│  │  ├─ PaymentDTO.cs
│  │  ├─ RegisterDTO.cs
│  │  ├─ ReportDTO.cs
│  │  ├─ SaleDTO.cs
│  │  ├─ ShipmentDTO.cs
│  │  ├─ SubmissionDTO.cs
│  │  ├─ UpdateCategoryDTO.cs
│  │  ├─ UpdateInvoiceDTO.cs
│  │  ├─ UpdateItemDTO.cs
│  │  ├─ UpdateItemReviewDTO.cs
│  │  ├─ UpdateOrderDTO.cs
│  │  ├─ UpdatePaymentDTO.cs
│  │  ├─ UpdateReportDTO.cs
│  │  ├─ UpdateSaleDTO.cs
│  │  ├─ UpdateShipmentDTO.cs
│  │  ├─ UpdateSubmissionDTO.cs
│  │  ├─ UpdateUserDTO.cs
│  │  ├─ UpdateUserTypeDTO.cs
│  │  ├─ UserDTO.cs
│  │  └─ UserTypeDTO.cs
│  ├─ Interfaces
│  │  ├─ Repositories
│  │  │  ├─ ICategoryRepository.cs
│  │  │  ├─ IInvoiceRepository.cs
│  │  │  ├─ IItemRepository.cs
│  │  │  ├─ IItemReviewRepository.cs
│  │  │  ├─ IOrderRepository.cs
│  │  │  ├─ IPaymentRepository.cs
│  │  │  ├─ IReportRepository.cs
│  │  │  ├─ ISaleRepository.cs
│  │  │  ├─ IShipmentRepository.cs
│  │  │  ├─ ISubmissionRepository.cs
│  │  │  ├─ IUserRepository.cs
│  │  │  └─ IUserTypeRepository.cs
│  │  └─ Services
│  │     ├─ ICategoryService.cs
│  │     ├─ IInvoiceService.cs
│  │     ├─ IItemReviewService.cs
│  │     ├─ IItemService.cs
│  │     ├─ IOrderService.cs
│  │     ├─ IPaymentService.cs
│  │     ├─ IReportService.cs
│  │     ├─ ISaleService.cs
│  │     ├─ IShipmentService.cs
│  │     ├─ ISubmissionService.cs
│  │     ├─ IUserService.cs
│  │     └─ IUserTypeService.cs
│  └─ Services
│     ├─ CategoryService.cs
│     ├─ InvoiceService.cs
│     ├─ ItemReviewService.cs
│     ├─ ItemService.cs
│     ├─ OrderService.cs
│     ├─ PaymentService.cs
│     ├─ ReportService.cs
│     ├─ SaleService.cs
│     ├─ ShipmentService.cs
│     ├─ SubmissionService.cs
│     ├─ UserService.cs
│     └─ UserTypeService.cs
├─ ArtExhibit.BackEnd.Domain
│  ├─ ArtExhibit.BackEnd.Domain.csproj
│  └─ Entities
│     ├─ Category.cs
│     ├─ Invoice.cs
│     ├─ Item.cs
│     ├─ ItemReview.cs
│     ├─ Order.cs
│     ├─ Payment.cs
│     ├─ Report.cs
│     ├─ Sale.cs
│     ├─ Shipment.cs
│     ├─ Submission.cs
│     ├─ User.cs
│     └─ UserType.cs
├─ ArtExhibit.BackEnd.Infrastructure
│  ├─ ArtExhibit.BackEnd.Infrastructure.csproj
│  ├─ Data
│  │  ├─ ApplicationDbContext.cs
│  │  ├─ Migrations
│  │  │  ├─ 20260210203719_InitialCreate.Designer.cs
│  │  │  ├─ 20260210203719_InitialCreate.cs
│  │  │  ├─ 20260211111315_FirstEntity.Designer.cs
│  │  │  ├─ 20260211111315_FirstEntity.cs
│  │  │  ├─ 20260211122108_UserTypeEntity.Designer.cs
│  │  │  ├─ 20260211122108_UserTypeEntity.cs
│  │  │  ├─ 20260225102710_UserImplemented.Designer.cs
│  │  │  ├─ 20260225102710_UserImplemented.cs
│  │  │  ├─ 20260225104832_ItemImplemented.Designer.cs
│  │  │  ├─ 20260225104832_ItemImplemented.cs
│  │  │  ├─ 20260225105419_SampleUsersItems.Designer.cs
│  │  │  ├─ 20260225105419_SampleUsersItems.cs
│  │  │  ├─ 20260225124750_SalesEntityAndImplementation.Designer.cs
│  │  │  ├─ 20260225124750_SalesEntityAndImplementation.cs
│  │  │  ├─ 20260225144216_OrderEntityAndImplementation.Designer.cs
│  │  │  ├─ 20260225144216_OrderEntityAndImplementation.cs
│  │  │  ├─ 20260226114431_InvoiceEntity.Designer.cs
│  │  │  ├─ 20260226114431_InvoiceEntity.cs
│  │  │  ├─ 20260226115211_InvoiceSampleData.Designer.cs
│  │  │  ├─ 20260226115211_InvoiceSampleData.cs
│  │  │  ├─ 20260226144328_ReportEntityAndSampleData.Designer.cs
│  │  │  ├─ 20260226144328_ReportEntityAndSampleData.cs
│  │  │  ├─ 20260226154302_ReportSampleDataMissing.Designer.cs
│  │  │  ├─ 20260226154302_ReportSampleDataMissing.cs
│  │  │  ├─ 20260226164945_ItemReviewEntityAndSampleData.Designer.cs
│  │  │  ├─ 20260226164945_ItemReviewEntityAndSampleData.cs
│  │  │  ├─ 20260227105711_SubmissionData.Designer.cs
│  │  │  ├─ 20260227105711_SubmissionData.cs
│  │  │  ├─ 20260227111232_PaymentData.Designer.cs
│  │  │  ├─ 20260227111232_PaymentData.cs
│  │  │  ├─ 20260227121610_ShipmentData.Designer.cs
│  │  │  ├─ 20260227121610_ShipmentData.cs
│  │  │  └─ ApplicationDbContextModelSnapshot.cs
│  │  └─ Product.db
│  └─ Repositories
│     ├─ CategoryRepository.cs
│     ├─ InvoiceRepository.cs
│     ├─ ItemRepository.cs
│     ├─ ItemReviewRepository.cs
│     ├─ OrderRepository.cs
│     ├─ PaymentRepository.cs
│     ├─ ReportRepository.cs
│     ├─ SaleRepository.cs
│     ├─ ShipmentRepository.cs
│     ├─ SubmissionRepository.cs
│     ├─ UserRepository.cs
│     └─ UserTypeRepository.cs
├─ ArtExhibit.BackEnd.slnx
└─ README.md
```
©generated by [Project Tree Generator](https://woochanleee.github.io/project-tree-generator)

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
