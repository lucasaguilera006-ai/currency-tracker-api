# CurrencyTrackerAPI

API REST desarrollada en **C# / ASP.NET Core** para consultar y llevar un historial de cotizaciones de divisas en tiempo real.

## 🚀 Funcionalidades

- **Cotización actual**: consulta el tipo de cambio entre dos monedas (por ejemplo, USD → ARS) contra un proveedor externo de cotizaciones.
- **Historial de consultas**: cada consulta realizada se guarda automáticamente en base de datos, permitiendo recuperar el historial de cotizaciones consultadas junto con la fecha y hora exacta.
- **Documentación interactiva** con Swagger, para probar los endpoints directamente desde el navegador.

## 🛠️ Tecnologías

- ASP.NET Core (C#)
- Entity Framework Core (migraciones y persistencia)
- Swagger / OpenAPI
- Base de datos relacional (SQL Server)

## 📌 Endpoints principales

### `GET /api/Currency/latest`
Devuelve la cotización actual entre dos monedas.

**Parámetros (query):**
| Nombre | Tipo | Descripción |
|---|---|---|
| `base_Currency` | string | Moneda base (ej: `USD`) |
| `target` | string | Moneda destino (ej: `ARS`) |

**Ejemplo de respuesta:**
```json
{
  "baseCurrency": "USD",
  "targetCurrency": "ARS",
  "exchangeRate": 1497.2898
}
```

### `GET /api/Currency/history`
Devuelve el historial de cotizaciones consultadas para un par de monedas.

**Parámetros (query):**
| Nombre | Tipo | Descripción |
|---|---|---|
| `base_Currency` | string | Moneda base (ej: `USD`) |
| `target` | string | Moneda destino (ej: `ARS`) |

**Ejemplo de respuesta:**
```json
[
  {
    "id": 1,
    "baseCurrency": "USD",
    "targetCurrency": "ARS",
    "exchangeRate": 1497.2898,
    "consultedAt": "2026-08-21T14:53:29.8224358"
  }
]
```

## 📷 Capturas

_Agregá acá 1-2 capturas de Swagger mostrando los endpoints en funcionamiento (`/latest` y `/history`)._

## ▶️ Cómo correrlo localmente

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/lucasaguilera006-ai/currency-tracker-api.git
   cd currency-tracker-api
   ```
2. Configurá la cadena de conexión a tu base de datos en `appsettings.json`.
3. Aplicá las migraciones:
   ```bash
   dotnet ef database update
   ```
4. Corré el proyecto:
   ```bash
   dotnet run
   ```
5. Abrí Swagger en el navegador (por defecto en `http://localhost:5243/swagger`) para probar los endpoints.

## 📄 Licencia

Este proyecto fue desarrollado como muestra de portfolio.