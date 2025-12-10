open System
open System.Windows.Forms
open Gui

[<EntryPoint>]
let main args =
    try
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(false)
        
        // Set up global exception handler
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        
        Application.ThreadException.Add(fun args ->
            MessageBox.Show(
                sprintf "An unexpected error occurred:\n\n%s\n\nStack trace:\n%s" 
                    args.Exception.Message 
                    args.Exception.StackTrace,
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            ) |> ignore
        )
        
        Application.Run(startGui())
        0
    with
    | ex ->
        MessageBox.Show(
            sprintf "Failed to start application:\n\n%s\n\nStack trace:\n%s" 
                ex.Message 
                ex.StackTrace,
            "Startup Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        ) |> ignore
        1
