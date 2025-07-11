# 🧩 TaskManager — ASP.NET Core CQRS API

Небольшой учебный проект для демонстрации **чистой архитектуры**, **CQRS-паттерна** и **тестируемого подхода к разработке** на ASP.NET Core.

## 🏗 Архитектура

Проект разделён по слоям согласно принципам **Clean Architecture**:

- TaskManager.API - Веб-слой (контроллеры)
- TaskManager.Application - CQRS, бизнес-правила, DTO, хендлеры
- TaskManager.Domain - Чистые бизнес-сущности и интерфейсы
- TaskManager.DataBase - EF Core, реализация доступа к данным
- TaskManager.UnitTests - xUnit + InMemory тесты

## 📋 Возможности API

| Действие | Метод | Endpoint |
|--------------------------------|-------------|-------------------------------|
| Создать задачу | `POST` | `/api/task/CreateTask` |
| Сменить статус задачи | `POST` | `/api/task/ChangeStatus` |
| Проверка возможности на завершение задачи | `GET` | `/api/task/CanBeDone` |
| Создание менеджера | `GET` | `/api/manager/CreateManager`|
