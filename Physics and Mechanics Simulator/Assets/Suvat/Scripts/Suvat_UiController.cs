﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Suvat_UiController : MonoBehaviour {

    public static Suvat_UiController instance;

    public GameObject ParticleInfomationCanvas;
    public GameObject ParticleGraphCanvas;

    public InputField S_x, S_y, S_z;
    public InputField U_x, U_y, U_z;
    public InputField V_x, V_y, V_z;
    public InputField A_x, A_y, A_z;
    public InputField Time;
    public InputField R_x, R_y, R_z;
    public InputField Radius;

    public Text Label_Time;

    public Dropdown DropBox_Dimentions;
    public Dropdown DropBox_Particle;
    public Dropdown DropBox_CameraTarget;

    public Slider Slider_SimulationSpeed;
    public Text Label_Speed;

    public Toggle Gravity;


    public void Start()
    {
        //Creates reference for all methods to access.
        instance = this;
        CameraController.DropBoxTarget = DropBox_CameraTarget;
        SimulateController.LabelTime = Label_Time;

        OnParticleInfomationButtonClicked();
        SetDimention_X(true);
        SetDimention_Y(true);
        SetDimention_Z(true);
    }

    #region Simulation buttons

    public void OnPauseClicked()
    {
        SimulateController.isSimulating = false;
    }
    public void OnPlayClicked()
    {
        if (SimulateController.simulationTime == SimulateController.maxTime)
        {
            //increasse time thing
        }
        else
        {
            SimulateController.isSimulating = true;
        }
    }

    public void OnSlider_SimulationSpeedChanged()
    {
        //Rounding to 2 Decimal places
        string value2DP = Slider_SimulationSpeed.value.ToString("n2");
        Label_Speed.text = "Speed = " + value2DP + "x";
    }
    #endregion

    public void OnCalculateClicked()
    {
        Suvat.OnCalculateClicked();
    }
    public void OnResetClicked()
    {
        ResetUI();
    }
    public void OnSimulateClicked()
    {
        Suvat.OnCalculateClicked();
        SimulateController.speedInput = Slider_SimulationSpeed;
        SimulateController.OnSimulateClicked();
    }

    public void OnParticleInfomationButtonClicked()
    {
        ParticleInfomationCanvas.SetActive(true);
        ParticleGraphCanvas.SetActive(false);
    }
    public void OnParticleGraphButtonClicked()
    {
        ParticleInfomationCanvas.SetActive(false);
        ParticleGraphCanvas.SetActive(true);
    }

    #region Updating dimentions input fields
    public void OnDropBox_DimentionsChanged()
    {
        int value = DropBox_Dimentions.value;
        switch(value)
        {
            case 0:
                SetDimention_X(true);
                SetDimention_Y(false);
                SetDimention_Z(false);
                changeFieldSize(0.319f);
                changeFieldPosition(200);
                break;
            case 1:
                SetDimention_X(true);
                SetDimention_Y(true);
                SetDimention_Z(false);
                changeFieldSize(0.66f);
                changeFieldPosition(261.5f);
                break;
            case 2:
                SetDimention_X(true);
                SetDimention_Y(true);
                SetDimention_Z(true);
                changeFieldSize(1);
                changeFieldPosition(322);
                break;
        } 
    }
    private void SetDimention_X(bool state)
    {
        S_x.gameObject.SetActive(state);
        U_x.gameObject.SetActive(state);
        V_x.gameObject.SetActive(state);
        A_x.gameObject.SetActive(state);
        R_x.gameObject.SetActive(state);
    }
    private void SetDimention_Y(bool state)
    {
        S_y.gameObject.SetActive(state);
        U_y.gameObject.SetActive(state);
        V_y.gameObject.SetActive(state);
        A_y.gameObject.SetActive(state);
        R_y.gameObject.SetActive(state);
    }
    private void SetDimention_Z(bool state)
    {
        S_z.gameObject.SetActive(state);
        U_z.gameObject.SetActive(state);
        V_z.gameObject.SetActive(state);
        A_z.gameObject.SetActive(state);
        R_z.gameObject.SetActive(state);
    }
    private void changeFieldSize(float size)
    {
        var temp_Time = Time.gameObject.transform.localScale;
        Time.gameObject.transform.localScale = new Vector3(size, temp_Time.y, temp_Time.z);
    }
    private void changeFieldPosition(float x)
    {
        var temp_Time = Time.gameObject.transform.localPosition;
        Time.gameObject.transform.localPosition = new Vector3(x, temp_Time.y, temp_Time.z);
    }
    #endregion


    public void OnDropBox_ParticleChanged()
    {
        int maximum = DropBox_Particle.options.Count;
        int value = DropBox_Particle.value;
        if (value == maximum - 1 && SimulateController.isSimulating == false)
        {
            AddOptionToDropBox(maximum);
        }

        //Updates values depending on the particle selected.
        UpdateValues();
    }

    private void AddOptionToDropBox(int size)
    {
        Dropdown.OptionData[] oldOptions = new Dropdown.OptionData[size + 1];
        for (int i = 0; i < size; i++)
        {
            oldOptions[i] = DropBox_Particle.options[i];
        }
        DropBox_Particle.options.Clear();
        DropBox_CameraTarget.options.Clear();
        string _text = "Free Roam ";
        DropBox_CameraTarget.options.Add(new Dropdown.OptionData() { text = _text });
        for (int i = 0; i < size - 1; i++)
        {
            DropBox_Particle.options.Add(oldOptions[i]);
            DropBox_CameraTarget.options.Add(oldOptions[i]);
        }
        _text = "Particle " + size.ToString();
        DropBox_Particle.options.Add(new Dropdown.OptionData() { text = _text });
        DropBox_CameraTarget.options.Add(new Dropdown.OptionData() { text = _text });

        _text = "Add Particle";
        DropBox_Particle.options.Add(new Dropdown.OptionData() { text = _text });

        DropBox_Particle.value = size - 2;
        DropBox_Particle.value = size - 1;
    }

    private void UpdateValues()
    {
        int current = DropBox_Particle.value;
        try
        {
            UpdateUI(Particle.Instances[current]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            ResetUI();
        }
    }

    public void OnDropBox_CameraTargetChanged()
    {
        int value = DropBox_CameraTarget.value;
        if (value == 0)
        {
            CameraController.isFreeRoam = true;
        }
        else
        {
            CameraController.isFreeRoam = false;
        }
    }

    public void UpdateUI(Particle values)
    {
        S_x.text = values.Displacement[0].ToString();
        S_y.text = values.Displacement[1].ToString();
        S_z.text = values.Displacement[2].ToString();

        U_x.text = values.InitialVelocity[0].ToString();
        U_y.text = values.InitialVelocity[1].ToString();
        U_z.text = values.InitialVelocity[2].ToString();

        V_x.text = values.FinalVelocity[0].ToString();
        V_y.text = values.FinalVelocity[1].ToString();
        V_z.text = values.FinalVelocity[2].ToString();

        A_x.text = values.Acceleration[0].ToString();
        A_y.text = values.Acceleration[1].ToString();
        A_z.text = values.Acceleration[2].ToString();

        Time.text = values.Time.ToString();

        R_x.text = values.InitialPosition[0].ToString();
        R_y.text = values.InitialPosition[1].ToString();
        R_z.text = values.InitialPosition[2].ToString();

        Radius.text = values.Radius.ToString();
    }

    public void ResetUI()
    {
        S_x.text = "";
        S_y.text = "";
        S_z.text = "";

        U_x.text = "";
        U_y.text = "";
        U_z.text = "";

        V_x.text = "";
        V_y.text = "";
        V_z.text = "";

        A_x.text = "";
        A_y.text = "";
        A_z.text = "";

        Time.text = "";

        R_x.text = "";
        R_y.text = "";
        R_z.text = "";

        Radius.text = "";
        Gravity.isOn = false;
    }


}
