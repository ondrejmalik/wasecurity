Pro spuštění je třeba nakonfigurovat v appdata/wasecurity/config.txt connection string
Pro přidání pfp musíte vložit png soubor tlačítkem dole v indexu 
Pro změnu hesla musíte vyplnit username, heslo, noveheslo.
Pro smazani prispevku zmacknete X u postu.
Pro smazani uzivatele se prihlaste jako admin a v admin panelu ho pomoci X smazte

## XSS
po vložení do username se zobrazí správně jako nový uživatel 
```
</p><script> alert(1) </script>
```

Další variace taky javascript netriggernou -
```
</h2></p><script> alert(1) </script>
</h2></h2></p><script> alert(1) </script>
</h2></h2></h2></p><script> alert(1) </script>
```
## XSRF
- aplikace je řešená přes websockety veškeré akce jsou tedy session based takže nelze.
Tohle se stát nemůže:
```
http://bank.com/transfer.do?acct=MARIA&amount=100000
```
## SQLInjection
- Řešeno přes SQLCommand Parametry
```
U funkce Login()
    MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE name = @name", connection);
                command.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Credentials.Id = reader["id"].ToString();
                        Credentials.Username = reader["name"].ToString();
                        Credentials.Password = reader["password"].ToString();
                        Credentials.Password = reader["password"].ToString();
                        i++;
                    }
                }
```
## Path traversal
- Je možný 
dostanete se do /objednavky ale nevytvoříte jí takže se vlastně nic nestane
Chyba je v této části kódu která hází error
```
@{
    if (Parameter.Parameter == null)
    {
        NavigationManager.NavigateTo("/");
    }
}
```
## DOS
- je samozřejmě možný
- řešení - cloudflare nebo jiný protection

--  Malík, Ráček, Shiska
