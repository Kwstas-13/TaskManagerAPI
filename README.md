# ✅ Task Manager API

REST API για διαχείριση tasks φτιαγμένο με **C# / .NET 10**.

## 🛠️ Τεχνολογίες
- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- JWT Authentication
- Swagger/OpenAPI

## ⚙️ Οδηγίες Εκκίνησης

### Προαπαιτούμενα
- .NET 10 SDK

### Εκκίνηση
```bash
cd TaskManagerAPI
dotnet run
```
API τρέχει στο: **http://localhost:5126**

Swagger UI: **http://localhost:5126/swagger**

## 👥 Endpoints

### Auth
- `POST /api/Auth/register` — Εγγραφή
- `POST /api/Auth/login` — Σύνδεση

### Tasks (απαιτεί JWT)
- `GET /api/Tasks` — Όλα τα tasks
- `POST /api/Tasks` — Νέο task
- `PUT /api/Tasks/{id}/complete` — Ολοκλήρωση task
- `DELETE /api/Tasks/{id}` — Διαγραφή task