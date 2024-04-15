using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public struct Rating
    {
        public string UserName { get; set; }
        public int Points { get; set; }
    }

    string filePath;
    public TextMeshProUGUI ratingText;
    public TMP_InputField name;
    public List<Rating> users = new List<Rating>();
    int score;
    int count;
    string json;

    void Start()
    {
        filePath = Application.persistentDataPath + "/Rating.json";
        Open();
    }

    public void Create()
    {
        score = 0;
        if(users.Count >= 6)
        {
            users.Remove(users[users.Count-1]);
        }
        Rating existingUser = users.Find(u => u.UserName == name.text);

        if (!EqualityComparer<Rating>.Default.Equals(existingUser, default(Rating)))
        {
            score = existingUser.Points;
            users.Remove(existingUser);
        }
            Rating newUser = new Rating();
            newUser.UserName = name.text;
            newUser.Points = BreakingBlocks.finalScore + score;
            users.Add(newUser);
        users.Sort((a, b) => b.Points.CompareTo(a.Points));
        json = JsonConvert.SerializeObject(users);
        File.WriteAllText(filePath, json);
        BreakingBlocks.finalScore = 0;
    }
    void Update()
    {
        ratingText.text = "";
        count = 1;
        foreach (Rating user in users)
        {
            ratingText.text +=count + ". " + user.UserName + ": " + user.Points + "\n";
            count++;
        }
    }
    public void Open()
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<Rating>>(json);
        }
    }
    public void Delete()
    {
        Rating existingUser = users.Find(u => u.UserName == name.text);

        if (!EqualityComparer<Rating>.Default.Equals(existingUser, default(Rating)))
        {
            users.Remove(existingUser);
            json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);
        }
    }
}
