SOURCE_IMAGE = os.getenv("SOURCE_IMAGE", default='acrtmc.azurecr.io/tap-demo/menu-api-uaaron-source')
LOCAL_PATH = os.getenv("LOCAL_PATH", default='.')
NAMESPACE = os.getenv("NAMESPACE", default='default')
NAME = "menu-api"

local_resource(
    'build',
    'dotnet publish -c Debug -o out',
    deps=['.'],
    ignore=['./obj', './bin', './.vscode', './out'],
)

k8s_custom_deploy(
    NAME,
    apply_cmd="tanzu apps workload apply -f config/workload.yaml --debug --live-update" +
              " --local-path " + LOCAL_PATH +
              " --source-image " + SOURCE_IMAGE +
              " --namespace " + NAMESPACE +
              " --yes >/dev/null" +
              " && kubectl get workload " + NAME + " --namespace " + NAMESPACE + " -o yaml",
    delete_cmd="tanzu apps workload delete " + NAME + " --namespace " + NAMESPACE + " --yes",
    deps=['./out'],
    container_selector='workload',
    live_update=[
        sync('./out', '/workspace')
    ]
)

k8s_resource(NAME, port_forwards=["8080:8080"],
            extra_pod_selectors=[{'serving.knative.dev/service': NAME}])

allow_k8s_contexts('aks-demo1-admin')