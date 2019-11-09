[<RequireQualifiedAccess>]
module Elmish.WinForms.Program

open System.Windows.Forms
open Elmish
type internal DispatchDelegate = delegate of unit -> unit

let startElmishLoop
    (config: ElmConfig)
    (element: Control)
    (program: Program<unit, 'model, 'msg, Binding<'model, 'msg> list>) =
  let mutable lastModel = None

  let setState model dispatch =
    match lastModel with
    | None ->
        let bindings = Program.view program model dispatch
        let vm = ViewModel<'model,'msg>(model, dispatch, bindings, config, "main")
        element.Tag <- vm
        lastModel <- Some vm
    | Some vm ->
        vm.UpdateModel model

  let uiDispatch (innerDispatch: Dispatch<'msg>) : Dispatch<'msg> =
    fun msg -> element.BeginInvoke(DispatchDelegate(fun () -> innerDispatch msg)) |> ignore

  program
  |> Program.withSetState setState
  |> Program.withSyncDispatch uiDispatch
  |> Program.run



/// Starts the WindowsForms dispatch loop. This is a blocking function.
let private startApp window =
  //if isNull Application.Current then Application () |> ignore
  //Application.Current.Run window
  Application.Run(mainForm = window)
  0


/// Starts the Elmish and WindowsForms dispatch loops. This is
/// a blocking function.
let runWindow window program =
  startElmishLoop ElmConfig.Default window program
  startApp window


/// Starts the Elmish and WindowsForms dispatch loops with the specified configuration.
/// This is a blocking function.
let runWindowWithConfig config window program =
  startElmishLoop config window program
  startApp window


/// Same as mkSimple, but with a signature adapted for Elmish.WindowsForms.
let mkSimpleWindowsForms
    (init: unit -> 'model)
    (update: 'msg  -> 'model -> 'model)
    (bindings: unit -> Binding<'model, 'msg> list) =
  Program.mkSimple init update (fun _ _ -> bindings ())


/// Same as mkProgram, but with a signature adapted for Elmish.WindowsForms.
let mkProgramWindowsForms
    (init: unit -> 'model * Cmd<'msg>)
    (update: 'msg  -> 'model -> 'model * Cmd<'msg>)
    (bindings: unit -> Binding<'model, 'msg> list) =
  Program.mkProgram init update (fun _ _ -> bindings ())


/// Same as mkProgramWindowsForms, except that init and update doesn't return Cmd<'msg>
/// directly, but instead return a CmdMsg discriminated union that is converted
/// to Cmd<'msg> using toCmd. This means that the init and update functions
/// return only data, and thus are easier to unit test. The CmdMsg pattern is
/// general; this is just a trivial convenience function that automatically
/// converts CmdMsg to Cmd<'msg> for you in init and update
let mkProgramWindowsFormsWithCmdMsg
    (init: unit -> 'model * 'cmdMsg list)
    (update: 'msg -> 'model -> 'model * 'cmdMsg list)
    (bindings: unit -> Binding<'model, 'msg> list)
    (toCmd: 'cmdMsg -> Cmd<'msg>) =
  let convert (model, cmdMsgs) =
    model, (cmdMsgs |> List.map toCmd |> Cmd.batch)
  mkProgramWindowsForms
    (init >> convert)
    (fun msg model -> update msg model |> convert)
    bindings


/// Traces all updates using System.Diagnostics.Debug.WriteLine.
let withDebugTrace program =
  program |> Program.withTrace (fun msg model ->
    System.Diagnostics.Debug.WriteLine(sprintf "New message: %A" msg)
    System.Diagnostics.Debug.WriteLine(sprintf "Updated state: %A" model)
  )

