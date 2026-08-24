# JtlDemo Runbook create by Lam Thong

## 1. Purpose

This runbook describes how to build, run, deploy, verify, troubleshoot,
and roll back the JtlDemo REST service.

The application was migrated from a Windows-coupled service to a
Linux-compatible ASP.NET Core application and packaged as a Docker
container.

A Helm chart is provided for deployment to a local Kubernetes cluster.

---

## 2. Prerequisites

The following tools are required:

- .NET 8 SDK
- Docker
- Kubernetes cluster
- kubectl
- Helm

Verify the tools:

```bash
dotnet --version
docker --version
kubectl version --client
helm version

Build Docker Image
docker build -t jtl-demo:local .
Run Docker Container
docker run -d \
  --name jtl-demo \
  -p 5000:8080 \
  -e ConnectionString="Server=localhost;Database=JtlDemo" \
  jtl-demo:local
Verify
curl http://localhost:5000/healthz
curl http://localhost:5000/api/items
curl http://localhost:5000/api/customers
curl http://localhost:5000/api/stats
Kubernetes / Helm
helm lint ./helm/jtl-demo

helm upgrade --install jtl-demo ./helm/jtl-demo \
  --namespace jtl-demo \
  --create-namespace

Check deployment:

kubectl get pods -n jtl-demo
kubectl get all -n jtl-demo
Port Forward
kubectl port-forward \
  svc/jtl-demo 5000:80 \
  -n jtl-demo

Then:

curl http://localhost:5000/healthz
Troubleshooting

Check pod logs:

kubectl logs -n jtl-demo deployment/jtl-demo

Check pod events:

kubectl describe pod -n jtl-demo <pod-name>

Check deployment:

kubectl get deployment -n jtl-demo
Rollback
helm history jtl-demo -n jtl-demo

Rollback to a previous revision:

helm rollback jtl-demo <REVISION> -n jtl-demo

Verify:

kubectl get pods -n jtl-demo
Cleanup
helm uninstall jtl-demo -n jtl-demo
kubectl delete namespace jtl-demo