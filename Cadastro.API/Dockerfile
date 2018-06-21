FROM microsoft/dotnet:2.0-sdk
COPY pub/ /root/
WORKDIR /root/
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "Cadastro.API.dll"]