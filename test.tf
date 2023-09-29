# Application Insights

resource "azurerm_application_insights" "app-insights-test" {
  name                = "pet-store-test"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"

  tags = {
    source              = "terraform"
    environment         = "test"
    github_project_name = "pet-store"
    github_file_name    = "test.tf"
  }
  
  lifecycle {
    prevent_destroy = true
  }
}

output "instrumentation_key_test" {
  value = azurerm_application_insights.app-insights-test.instrumentation_key
  sensitive = true
}

output "app_id_test" {
  value = azurerm_application_insights.app-insights-test.app_id
  sensitive = true
}