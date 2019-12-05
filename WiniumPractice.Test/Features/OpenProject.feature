Feature: Open a project

	The user opens a project within M4 in order to continue their work.

	Background: M4 has just started
		Given that M4 has just opened

	@open-project
	Scenario: Open a project by picking a project
		When the user picks a project from his filesystem
		Then the project is opened