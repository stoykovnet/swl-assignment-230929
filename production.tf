# Application Insights

resource "azurerm_application_insights" "app-insights-prod" {
  name                = "<REPO_NAME>-prod"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"

  tags = {
    source              = "terraform"
    environment         = "production"
    github_project_name = "<REPO_NAME>"
    github_file_name    = "production.tf"
  }
  
  lifecycle {
    prevent_destroy = true
  }
}

output "instrumentation_key_prod" {
  value = azurerm_application_insights.app-insights-prod.instrumentation_key
  sensitive = true
}

output "app_id_prod" {
  value = azurerm_application_insights.app-insights-prod.app_id
  sensitive = true
}