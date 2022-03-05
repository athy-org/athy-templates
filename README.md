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
--Athy_ContentType application/json --Athy_EndpointRoute /{petId} --Athy_ReturnTypeName Pet --Athy_ReturnTypeBody JsonStringOfTheSchema \
--Athy_HttpGetMethodName getPetById --Athy_PathParam petId
```

## conventions / best-practices

Prefix all template symbols (parameters) with `Template__`. This enables the template solution to still be compiled, whereas something like {x} would not.

## notes

- Deciding between using a parametised approach to the templates e.g. {ValueToReplace} versus some "unique" name is important. A combination can be used, but caution is advised.

## references

- [templating api reference](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
