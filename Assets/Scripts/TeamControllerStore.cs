using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamControllerStore : MonoBehaviour
{
    public Team[] teams;
    public int freeTeams = 24;

    private Text freeTeamsText;

    TeamController teamController;

    private void Start()
    {
        freeTeamsText = GameObject.Find("TeamsStore").GetComponent<Text>();
        teamController = GameObject.Find("TeamController").GetComponent<TeamController>();

        ShowTeams();
    }

    public int CheckTeams()
    {
        int bustTeams = 0;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy > 0)
            {
                teams[i].busy -= 1;
                bustTeams++;
            }
        }

        return bustTeams;
    }

    public int openTeams()
    {
        freeTeams = 0;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy == 0 && teams[i].hired == true)
            {
                freeTeams++;
            }
        }
        return freeTeams++; ;
    }

    public int CheckBusyTeams()
    {
        int free = 0;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy > 0 || teams[i].hired == true)
            {
                free++;
            }
        }

        Debug.Log(free);
        return free;
    }

    public bool CheckFree(int count)
    {
        int free = 0;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy == 0)
            {
                free++;

                if (free == count)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool BusyTeam(int count, int turns)
    {
        int teamsBused = 0;

        if (CheckFree(count) == false)
        {
            return false;
        }

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy == 0)
            {
                teams[i].busy = turns;
                teamsBused++;

                if (teamsBused == count)
                {
                    return true;
                }
            }
        }



        return false;
    }

    public void ShowTeams()
    {
        freeTeams = 0;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].busy == 0 && teams[i].hired == false)
            {
                freeTeams++;
            }
        }

        int busyTeams = 24 - freeTeams;
        freeTeamsText.text = busyTeams.ToString();
    }

    public void HireTeam()
    {
        if (CheckBusyTeams() + teamController.CheckBusyTeams() >= 24) return;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].hired == false && teams[i].busy == 0)
            {
                teams[i].hired = true;
                break;
            }
        }

        ShowTeams();
    }

    public void DismissTeam()
    {
        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].hired == true && teams[i].busy == 0)
            {
                teams[i].hired = false;
                break;
            }
        }

        ShowTeams();
    }

    public bool ReserveTeams(int count, int turns)
    {

        int busyTeams = count;
        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].hired == true && teams[i].busy == 0)
            {
                teams[i].busy = turns;
                busyTeams--;
            }


            if (busyTeams == 0)
            {
                return true;
            }
        }

        for (int i = 0; i < teams.Length; i++)
        {
            if (busyTeams == count)
            {
                return false;
            }

            if (teams[i].hired == true && teams[i].busy == turns)
            {
                teams[i].busy = turns;
                busyTeams++;
            }
        }

        ShowTeams();
        return false;
    }
}
