🚀 Architecture Overview
API Layer: Azure Functions (Isolated Worker Model) for high scalability and serverless efficiency.
ML Engine: ML.NET utilizing TorchSharp (BERT architecture) for advanced NLP.
Efficiency: Implements PredictionEnginePool for thread-safe, high-concurrency predictions.
CI/CD: Automated deployment pipeline via GitHub Actions to Azure App Service.
🛠️ Project Structure
MyFunctionApp/: The production-ready Azure Function API.
MyMLApp/: The training project and .mbconfig used to generate the sentiment model.
SentimentModel.mlnet: The serialized deep learning model.
⚙️ Setup & Installation
Prerequisites
Visual Studio 2022 (v17.12+) or VS 2026.
.NET 10 SDK.
Azure Functions Core Tools.
Local Development
Clone the repository:
bash
git clone <your-repo-url>
Use code with caution.
Restore NuGet Packages:
bash
dotnet restore
Use code with caution.
Model Configuration:
Ensure SentimentModel.mlnet is in the MyFunctionApp root and its properties are set to Copy to Output Directory: Copy if newer.
Run:
Press F5 in Visual Studio to start the local Functions host.
📡 API Usage
Endpoint: GET/POST /api/AnalyzeSentiment
Parameters:
Name	Type	Description
news	string	The news headline to analyze.
Example Request:
GET http://localhost:7132/api/AnalyzeSentiment?news=Markets reach record highs amid tech surge
Example Response:
json
{
  "headline": "Markets reach record highs amid tech surge",
  "sentiment": "Positive",
  "confidence": [0.98, 0.01, 0.01]
}
Use code with caution.
☁️ Deployment
This repository is configured for GitHub Actions. Any push to the main branch automatically:
Builds the .NET 10 environment.
Validates dependencies (TorchSharp, ML.NET).
Deploys the artifact to the Azure Function App.
🛡️ Maintainability & Monitoring
Logging: Integrated with Azure Application Insights for real-time telemetry.
Resiliency: Designed with Dependency Injection to manage the model's lifecycle and memory footprint.
Scalability: Ready for Azure Functions Premium Plan to handle large bursts of traffic without cold-start delays.
Developed as part of a Cloud-Native Microservices engineering exercise.
