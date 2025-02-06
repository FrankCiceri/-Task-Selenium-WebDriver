Feature: Validate Navigation to Services Section

  As a user
  I want to navigate to a service category from the Services menu
  So that I can view the relevant information

  Scenario Outline: Validate Navigation to Services Category
    Given I am on the EPAM homepage
    When I hover over the Services menu
    And I select "<ServiceCategory>" from the dropdown
    Then the page title should be "<ServiceCategory>"
    And the "Our Related Expertise" section should be visible

    Examples:
      | ServiceCategory  |
      | Generative AI    |
      | Responsible AI   |