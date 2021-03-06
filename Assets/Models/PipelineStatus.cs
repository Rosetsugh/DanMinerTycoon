﻿using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A collection of statistics for a given <see cref="Pipeline"/> that
/// provides a method for upgrading them.
/// </summary>
public class PipelineStatus : MonoBehaviour
{
    #region Properties

    #region Private

// Disables warning for unassigned variables, as these
// variables will be set in the Unity editor.
#pragma warning disable 0649

    /// <summary>
    /// The default travel speed of a <see cref="Worker"/>
    /// in the related <see cref="Pipeline"/>.
    /// </summary>
    [SerializeField]
    private float BaseWorkerSpeed;

    /// <summary>
    /// The default carrying capacity of a <see cref="Worker"/>
    /// in the related <see cref="Pipeline"/>.
    /// </summary>
    [SerializeField]
    private float BaseWorkerCapacity;

    /// <summary>
    /// The initial cost to upgrade the related <see cref="Pipeline"/>.
    /// </summary>
    [SerializeField]
    private float BaseUpgradeCost;
    
    /// <summary>
    /// A reference to the Text field displaying the <see cref="Level"/>.
    /// </summary>
    [SerializeField]
    private Text LevelText;
    
    /// <summary>
    /// A reference to the text of the button used to upgrade the Pipeline Status.
    /// </summary>
    [SerializeField]
    private Text UpgradeButtonText;

#pragma warning restore 0649

    /// <summary>
    /// Private variable for <see cref="Level"/>
    /// </summary>
    /// <remarks>
    /// Not for general use, <see cref="Level"/>
    /// should be used to access and mutate this
    /// value.
    /// </remarks>
    [SerializeField]
    [Obsolete("Use property Level instead.")]
    private int _level;

    #endregion

    /// <summary>
    /// A reference to the player's <see cref="CashStore"/>.
    /// </summary>
    public CashStore PlayerCash 
        => GameObject.FindWithTag("Player").GetComponent<CashStore>();

    /// <summary>
    /// The current travel speed of a <see cref="Worker"/>
    /// in the related <see cref="Pipeline"/>.
    /// </summary>
    /// <remarks>
    /// Dependent on the current<see cref="Level"/> of the pipeline.
    /// </remarks>
    public float WorkerSpeed => BaseWorkerSpeed * Level;

    /// <summary>
    /// The current carrying capacity of a <see cref="Worker"/>
    /// in the related <see cref="Pipeline"/>.
    /// </summary>
    /// <remarks>
    /// Dependent on the current<see cref="Level"/> of the pipeline.
    /// </remarks>
    public float WorkerCapacity => BaseWorkerCapacity * Level;

    /// <summary>
    /// The current cost to upgrade the related <see cref="Pipeline"/>.
    /// </summary>
    /// <remarks>
    /// Dependent on the current<see cref="Level"/> of the pipeline.
    /// </remarks>
    public float UpgradeCost => BaseUpgradeCost * Level;

    /// <summary>
    /// The current level of the <see cref="Pipeline"/>, which can
    /// be upgraded to improve its efficiency.
    /// </summary>
    public int Level
    {
// Disable warnings for using Obsolete property.
#pragma warning disable 0618
        get { return _level; }
        private set
        {
            _level = value;
            LevelText.text = value.ToString();
            UpgradeButtonText.text = $"Upgrade! (Cost: {UpgradeCost.ToString("c2")}";
        }
#pragma warning restore 0618
    }

    #endregion

    #region MonoBehaviour Methods

    /// <summary>
    /// Called at the start of this component's lifecycle, this
    /// method sets the <see cref="Level"/> value to update the display.
    /// </summary>
    public void Start()
    {
        Level = Level;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Increments the level of the base.
    /// </summary>
    public void Upgrade()
    {
        var cash = GameObject.FindWithTag("Player");
        PlayerCash.Extract(UpgradeCost);
        Level++;
    }

    #endregion
}

