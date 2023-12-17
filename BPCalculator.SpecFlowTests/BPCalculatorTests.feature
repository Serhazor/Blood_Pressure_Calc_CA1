Feature: Blood Pressure Result Message Display

  Scenario: Verify result message is displayed for ideal blood pressure
    Given I am on the blood pressure calculator page
    When I enter "120" into the systolic field
    And I enter "80" into the diastolic field
    And I press the submit button
    Then I should see the message "Ideal Blood Pressure"
