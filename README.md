# 📰 News Sentiment Analysis Microservice
### .NET 10 | Azure Functions | ML.NET | TorchSharp

This project is a scalable, cloud-native API designed to perform real-time sentiment analysis on news headlines using a Deep Learning model.

---

## 🚀 Architecture Overview
*   **API Layer:** Azure Functions (**Isolated Worker Model**) for high scalability and serverless efficiency.
*   **ML Engine:** **ML.NET** utilizing **TorchSharp** (BERT architecture) for advanced NLP.
*   **Efficiency:** Implements `PredictionEnginePool` for thread-safe, high-concurrency predictions.
*   **CI/CD:** Automated deployment pipeline via **GitHub Actions** to Azure.

---

## 🛠️ Project Structure
*   `MyFunctionApp/`: The production-ready Azure Function API.
*   `MyMLApp/`: The training project and `.mbconfig` used to generate the model.
*   `SentimentModel.mlnet`: The serialized deep learning model artifact.

---

## ⚙️ Setup & Installation

### Prerequisites
*   **Visual Studio 2022 (v17.12+)** or **VS 2026**
*   **.NET 10 SDK**
*   **Azure Functions Core Tools**

### Local Development
1.  **Clone the repository:**
    ```bash
    git clone <your-repo-url>
    ```
2.  **Restore NuGet Packages:**
    ```bash
    dotnet restore
    ```
3.  **Model Configuration:**
    Ensure `SentimentModel.mlnet` is in the `MyFunctionApp` root. Set its properties to:
    *   `Build Action`: Content
    *   `Copy to Output Directory`: **Copy if newer**
4.  **Run:**
    Press **F5** in Visual Studio to start the local Functions host.

---

## 📡 API Usage
**Endpoint:** `GET/POST /api/AnalyzeSentiment`

### Parameters

| Name | Type | Description |
| :--- | :--- | :--- |
| **news** | `string` | The news headline to analyze. |

### Example Request
`GET http://localhost:7132/api/AnalyzeSentiment?news=Markets reach record highs`

### Example Response
```json
{
  "headline": "Markets reach record highs",
  "sentiment": "Positive",
  "confidence": [0.98, 0.01, 0.01]
}
---

## ☁️ Deployment
This repository is configured for **GitHub Actions**. Any push to the `main` branch automatically triggers the following pipeline:
*   **Build:** Compiles the solution in a native **.NET 10** environment.
*   **Validation:** Verifies all deep learning dependencies (**TorchSharp**, **ML.NET**).
*   **Release:** Deploys the finalized artifact to the **Azure Function App** service.

---

## 🛡️ Maintainability & Monitoring
*   **Logging:** Integrated with **Azure Application Insights** for full-stack telemetry and real-time error tracking.
*   **Resiliency:** Designed using **Dependency Injection** and `PredictionEnginePool` to manage the model's memory footprint and ensure thread-safety.
*   **Scalability:** Fully optimized for **Azure Functions Premium Plans** to eliminate "cold starts" and handle high-volume traffic bursts.

---
*Developed as part of a Cloud-Native Microservices engineering exercise.*
