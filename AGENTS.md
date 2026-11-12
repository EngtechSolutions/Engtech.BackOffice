# Code Review Rules

## .NET
- Follow the existing C#, ABP, and project conventions; preserve nullable annotations and avoid unrelated public API changes.
- Keep changes scoped to the requested behavior and reuse existing dependencies and abstractions.

## Blazor and Localization
- Follow the existing MudBlazor component patterns in this module.
- Put user-visible text in the Binance localization resources and keep English and Spanish keys aligned.

## Verification
- Build the affected project and run relevant tests when available; report checks that could not be run.
