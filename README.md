
### This is the source code of the CRUD REST API using .NET 6 

# Usage

Simply `git clone https://github.com/shukui/InventoryAPI` and `dotnet run --project InventoryAPI`.

# API Definition


## Create Inventory

### Create Inventory Request

```js
POST /Inventorys
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy Inventory..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Create Inventory Response

```js
201 Created
```

```yml
Location: {{host}}/Inventorys/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy Inventory..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Inventory

### Get Inventory Request

```js
GET /Inventorys/{{id}}
```

### Get Inventory Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy Inventory..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Inventory

### Update Inventory Request

```js
PUT /Inventorys/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy Inventory..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Inventory Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Inventorys/{{id}}
```

## Delete Inventory

### Delete Inventory Request

```js
DELETE /Inventorys/{{id}}
```

### Delete Inventory Response

```js
204 No Content
```

