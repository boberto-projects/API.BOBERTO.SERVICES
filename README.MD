# Base para o projeto api-boberto-services

### Essa é uma tentativa de executar o padrão CQRS de forma mais automatizada.
### Usando reflection para criar as instâncias das rotas e segregando por Comando e Query e responsabiliddes diferentes.


# Objetivo

* Gerenciamento do Docker
* Gerenciamento de notificação por push notification usando ntfy
* Gerenciamento de webhooks para notificação
* Middleware entre serviços que requerem autenticação e api-authentication-boberto
* Gerenciamento de filas para serviços entre o Launcher Boberto, api-modpackmanager
