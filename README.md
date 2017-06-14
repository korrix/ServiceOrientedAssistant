# ServiceOrientedAssistant
Simple project involving Service Oriented Architecture

## Services
* **Time service** is providing current time
* **Weather service** is providing weather forecast from external JSON REST API (Using Newtonsoft Json.NET library + persists PerSession state)
* **Todo service** is providing simple todo list memorization feature (Using LiteDB)

## CLI Interface
* **Assistant** solution is a simple CLI connecting those three services
