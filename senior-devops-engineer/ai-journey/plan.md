# Engineering Plan

## Phase 1 - Understand the application

- Inspect the solution and project references.
- Identify Windows-specific projects and runtime dependencies.
- Identify modules that can run independently on Linux.
- Identify the composition root and host-level Windows coupling.

## Phase 2 - Remove unnecessary Windows coupling

- Move platform-independent modules into a neutral assembly.
- Update project references.
- Change the REST server target framework to net8.0.
- Keep genuinely Windows-specific modules isolated.

## Phase 3 - Make the host Linux-compatible

- Remove Windows Event Log dependency.
- Replace Windows-specific configuration access with environment-based
  configuration.
- Validate startup on Ubuntu/WSL.

## Phase 4 - Validate application behavior

Run:

- dotnet restore
- dotnet build
- dotnet test
- local application execution
- endpoint verification

## Phase 5 - Containerize

- Create a multi-stage Dockerfile.
- Use ASP.NET Core runtime image.
- Run the application as non-root.
- Add container health checking.
- Verify the Linux image.

## Phase 6 - Kubernetes

- Create Helm chart.
- Configure Deployment and Service.
- Add readiness/liveness probes.
- Add resource requests and limits.
- Configure non-root security context.
- Deploy to a local Kubernetes cluster.

## Phase 7 - Operational validation

- Verify Pod health.
- Verify Service endpoints.
- Verify application endpoints.
- Test failure scenarios.
- Document rollback procedure.

## Phase 8 - Documentation

- README
- Runbook
- Reflection
- AI journey