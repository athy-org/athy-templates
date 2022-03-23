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
--Athy__ControllerName PetController --Athy__ControllerRoute /pet \
--Athy__ContentType application/json --Athy__EndpointRoute {petId} --Athy__ReturnTypeName Pet --Athy__ReturnTypeBody JsonStringOfTheSchema \
--Athy__HttpGetMethodName GetPetById --Athy__PathParam petId --Athy__EndpointDescription "Find pet by ID"

dotnet new athy-web-api-open-api \
--Athy__ControllerName StoreController --Athy__ControllerRoute /store \
--Athy__ContentType application/json --Athy__EndpointRoute inventory --Athy__ReturnTypeName StatusCodeQuantityMap --Athy__ReturnTypeBody JsonStringOfTheSchema \
--Athy__HttpGetMethodName GetInventory --Athy__PathParam --Athy__EndpointDescription "Returns pet inventories by status"

dotnet new athy-web-api-open-api \
--Athy__ControllerName StoreController --Athy__ControllerRoute /store \
--Athy__ContentType application/json --Athy__EndpointRoute order/{orderId} --Athy__ReturnTypeName Order --Athy__ReturnTypeBody JsonStringOfTheSchema \
--Athy__HttpGetMethodName GetOrderById --Athy__PathParam orderId --Athy__EndpointDescription "Find purchase order by ID" --Athy__HttpMethod HttpGet
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
- solutions: don't try to run multiple times, use below solutions to allow once-off runs.

- issue: params need to be specific to map to the correct endpoint code. can't use the same param name for a GET and a POST if they have different schemas in actuality. e.g., can't use Athy__ReturnTypeName over and over for each endpoint as each endpoint will probably have different return types, so the last endpoint would replace all the others.

- solutions: params need to be specific. e.g., need param set for _GET_, _POST_, etc. so Athy__ReturnTypeName_Get, Athy__ReturnTypeName_Post etc.
then, generator-cli will have to match up `dotnet new` call from swagger spec such that open-api `path` for `get` goes to a param for `_Get`, etc.
- solutions: the entire endpoint code is completely parametised. this will likely not be a 'runnable template project' anymore. so, we have param Athy__HttpMethod
which is fille in by the generator-cli from the swagger spec, and replaced by `HttpGet` c# code etc. in this case only one "endpoint" sample exists because it is re-used.

- issue: controller sample template needs to have multiple of the same HTTP method, so even Athy__ReturnTypeName_Get is insufficient.
- solutions: dev uses Athy__ReturnTypeName_Get params, but generator-cli will auto-append numbers e.g, Athy__ReturnTypeName_Get_1, per set of methods. so we will actually be generating the template itself a bit?

- issue: similar param names will overwrite each other partially?
- solutions: test if this is the case?
- [no]

## decisions

- can't use `dotnet new` out-the-box for open-api gen. so,
- write the tool to pull in the controller template.
- this tmpl must be using the cli variable API e.g. Athy___.
- the tmpl contains only one method.
- the cli will use the open-api spec to write out a new version of the template.
- the new tmpl version will have x methods for each endpoint-path in the open-api spec.
- the cli will then use this new tmpl_generated with params Athy__HttpMethod_1 etc. and map from the spec.
- schema models will also live wherever in the solution structure that they are defined with an Athy___ param.

or

- investigate using other tools for the merge function?
- yeoman.

and/or

- Nuget pkg for placeholder types.
- [no] Run template for file vs for values - --force required?
- [done] Document an example workflow for the dev.

no _1's but rather, run template and append to output???
