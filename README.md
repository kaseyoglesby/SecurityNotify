# SecurityNotify

SecurityNotify is a standalone WPF app. built in C# using VisualStudio 2017. The application aims to mimic a physical panic button.
Using a single mouse click, the user can send an emergency page to Security at their facility that alerts Security to their immediate need.
The application also provides a way to contact security on a non-emergent basis.

SecurityNotify uses the Clickatell API, sending text messages via REST and receiving a response in the form of a JSON query.
