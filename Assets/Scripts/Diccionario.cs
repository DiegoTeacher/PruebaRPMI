using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diccionario : MonoBehaviour
{
    public string currencyToSearch;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, char> currencies = new Dictionary<string, char>();
        currencies.Add("euro", '€');
        currencies.Add("dollar", '$');
        currencies.Add("yen", '¥');
        
        if(currencies.ContainsKey(currencyToSearch.ToLower()))
        {
            print(currencies[currencyToSearch.ToLower()]);
        }
        else
        {
            Debug.LogError("No contiene esa key");
        }
    }
}
