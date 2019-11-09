﻿module Elmish.WinForms.Samples.SingleCounter.Program
open SingleCounter.Views
open System
open Elmish
open Elmish.WinForms

type Model =
  { Count: int
    StepSize: int }

let init =
  { Count = 0
    StepSize = 1 }

type Msg =
  | Increment
  | Decrement
  | SetStepSize of int
  | Reset

let update msg m =
  match msg with
  | Increment -> { m with Count = m.Count + m.StepSize }
  | Decrement -> { m with Count = m.Count - m.StepSize }
  | SetStepSize x -> { m with StepSize = x }
  | Reset -> init

let bindings () : Binding<Model, Msg> list = [
  "CounterValue" |> Binding.oneWay (fun m -> m.Count)
  "Increment" |> Binding.cmd Increment
  "Decrement" |> Binding.cmd Decrement
  "StepSize" |> Binding.twoWay((fun m ->  m.StepSize), SetStepSize)
  "Reset" |> Binding.cmdIf(Reset, (<>) init)
]


[<EntryPoint; STAThread>]
let main _ =
  Program.mkSimpleWindowsForms (fun () -> init) update bindings
  |> Program.withConsoleTrace
  |> Program.runWindowWithConfig
    { ElmConfig.Default with LogConsole = true; Measure = true }
    (new MainWindow())
