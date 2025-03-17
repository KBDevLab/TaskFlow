# SQL Export

Generated on 2025-03-17 17:26:49.183684628 UTC by Fabricate v1.1.0

## Instructions

To load the data into your PostgreSQL database, execute the following command replacing the values with your own:

```bash
export PGPASSWORD=<password>
psql postgres://<user>@<host>:<port>/<db> -f load.sql
```

## Exported tables

This is the list of exported tables, with their corresponding row count:

    comments: 100 rows
    projects: 100 rows
    tasks: 100 rows
    users: 100 rows