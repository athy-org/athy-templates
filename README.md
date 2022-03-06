# dotnet templating notes

## concepts

1. item-templates: a template for just a file or set of files / config etc
2. project-templates: a full .csproj etc.

## commands

```sh
# install a template from local files in . dir
dotnet new --install .

# list installed templates
dotnet new --list

# create new console project / run template named console
dotnet new console

# run template named stringext
dotnet new stringext

# uninstall template from local files in current dir
dotnet new --uninstall .

# e.g. usage of more advanced template with additional options (and --dry-run appended for info)
dotnet new domain-abstractions-web-api --ClientCode abc --ProjectCode def --HttpPort 5200 --HttpsPort 5201 --HasAdaptor false --HasDatabase true --dry-run
dotnet new domain-abstractions-web-api --ClientCode Abc --ProjectCode Def --HttpPort 5200 --HttpsPort 5201 --dry-run

# more current sample usages
dotnet new athy-web-api --ClientCode OpenAPI --ProjectCode PetStore --HttpPort 6000 --HttpsPort 6001

dotnet new athy-web-api-open-api \
--ClientCode OpenAPI --ProjectCode PetStore --Athy_ControllerName PetController --Athy_ControllerRoute /pet \
--Athy_ContentType application/json --Athy_EndpointRoute {petId} --Athy_ReturnTypeName Pet --Athy_ReturnTypeBody JsonStringOfTheSchema \
--Athy_HttpGetMethodName GetPetById --Athy_PathParam petId --Athy_EndpointDescription "Find pet by ID"

dotnet new athy-web-api-open-api \
--ClientCode OpenAPI --ProjectCode PetStore --Athy_ControllerName StoreController --Athy_ControllerRoute /store \
--Athy_ContentType application/json --Athy_EndpointRoute inventory --Athy_ReturnTypeName StatusCodeQuantityMap --Athy_ReturnTypeBody JsonStringOfTheSchema \
--Athy_HttpGetMethodName GetInventory --Athy_PathParam --Athy_EndpointDescription "Returns pet inventories by status"

dotnet new athy-web-api-open-api \
--ClientCode OpenAPI --ProjectCode PetStore --Athy_ControllerName StoreController --Athy_ControllerRoute /store \
--Athy_ContentType application/json --Athy_EndpointRoute order/{orderId} --Athy_ReturnTypeName Order --Athy_ReturnTypeBody JsonStringOfTheSchema \
--Athy_HttpGetMethodName GetOrderById --Athy_PathParam orderId --Athy_EndpointDescription "Find purchase order by ID"
```

## conventions / best-practices

Prefix all template symbols (parameters) with `Template__`. This enables the template solution to still be compiled, whereas something like {x} would not.

## notes

- Deciding between using a parametised approach to the templates e.g. {ValueToReplace} versus some "unique" name is important. A combination can be used, but caution is advised.

## references

- [templating api reference](https://github.com/dotnet/templating/wiki/Reference-for-template.json)

## issues and solutions

- issue: cannot merge the same file with another, have to use --force. so, you can't run a template x times for the same output file.
you have to specify everything at once for that template run.

- solutions: ?

- issue: params need to be specific to map to the correct endpoint code. can't use the same param name for a GET and a POST if they have different schemas in actuality. e.g., can't use Athy_ReturnTypeName over and over for each endpoint as each endpoint will probably have different return types, so the last endpoint would replace all the others.

- solutions: params need to be specific. e.g., need param set for _GET_, _POST_, etc. so Athy_ReturnTypeName_Get, Athy_ReturnTypeName_Post etc.
then, generator-cli will have to match up `dotnet new` call from swagger spec such that open-api `path` for `get` goes to a param for `_Get`, etc.

- solutions: the entire endpoint code is completely parametised. this will likely not be a 'runnable template project' anymore. so, we have param Athy_HttpMethod
which is fille in by the generator-cli from the swagger spec, and replaced by `HttpGet` c# code etc. in this case only one "endpoint" sample exists because it is re-used.

- issue: controller sample template needs to have multiple of the same HTTP method, so even Athy_ReturnTypeName_Get is insufficient.

- solutions: dev uses Athy_ReturnTypeName_Get params, but generator-cli will auto-append numbers e.g, Athy_ReturnTypeName_Get_1, per set of methods. so we will actually be generating the template itself a bit?

- issue: similar param names will overwrite each other partially?

- solutions: test if this is the case?
