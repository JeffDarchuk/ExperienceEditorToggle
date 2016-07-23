# ExperienceEditorToggle
Sitecore module to make the experience editor's ribbon be toggle-able

This module patches into sitecore's pipeline code that renders the Experience Editor ribbon and makes it toggleable.  This becomes especially useful when using a fixed header or just generally for getting more in context editing real estate.

A hamberger button is added to the upper right corner in place of the ribbon.  Clicking this button will expand the ribbon and set a cookie so ongoing page views will have the ribbon in a consistant state.

additionally you can expand/collapse the Ribbon with the keyboard shortcut ctr+shift+s

##### This is for Sitecore 8 sites running MVC

### Getting it
There's a [Nuget package](https://www.nuget.org/packages/ExperienceEditorToggle/) for this that consists of a DLL and a config patch.  The patch will be installed at app_config/include/ExperienceEditorToggle.config

### How does it work?
We patch into the pipeline that sitecore uses to generate the EE ribbon to begin with and add some markup/style/js to facilitate collapsing the ribbon and expanding the ribbon while storing your preference in a cookie so it persists.
