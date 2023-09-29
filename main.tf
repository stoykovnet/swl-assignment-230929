terraform {
  backend "azurerm" {
    resource_group_name  = "Terraform"
    storage_account_name = "swlterraformsa"
    container_name       = "tfstate"
    key                  = "pet-store.tfstate"
  }

  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "=2.81.0"
    }
  }
}

provider "azurerm" {
  features {}
}


# Resource group

resource "azurerm_resource_group" "rg" {
  name     = "pet-store"
  location = "West Europe"

  tags = {
    source              = "terraform"
    environment         = "production,test"
    github_project_name = "pet-store"
    github_file_name    = "main.tf"
  }
  
  lifecycle {
    prevent_destroy = true
  }
}