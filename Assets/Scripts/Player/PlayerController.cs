using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour, IShopCustomer
{
    [SerializeField] private PlayerModel _model;
    [SerializeField] private PlayerView _view;
    [SerializeField] private CoinsHandler _coinsHandler;
    [SerializeField] private InventoryHandler _inventory;

    [SerializeField] float idleThreshold = 0.2f;
    
    private const float ZERO_THRESHOLD = 0.01f;

    private float _lastHInput;
    private float _lastVInput;
    private float _xAnim;
    private float _yAnim;

    private bool _inputBlocked;

    #region Handled Events
    
    //I subscribe methods that I want to be fired when an event occurs
    //In this case, I want to block the inputs when the game is paused
    private void OnEnable()
    {
        EventsManager.SubscribeToEvent("EV_PAUSE_GAME", StopInputCheck);
        EventsManager.SubscribeToEvent("EV_RESUME_GAME", ResumeInputCheck);
    }
    
    //When the player is disabled, unsubscribes the methods to avoid persistence 
    private void OnDisable()
    {
        EventsManager.UnsubscribeToEvent("EV_PAUSE_GAME", StopInputCheck);
        EventsManager.UnsubscribeToEvent("EV_RESUME_GAME", ResumeInputCheck);
    }

    private void StopInputCheck()
    {
        _inputBlocked = true;
        Move(0, 0);
    }

    private void ResumeInputCheck()
    {
        _inputBlocked = false;
    }

    #endregion

    private void FixedUpdate()
    {
        if(!_inputBlocked)
            CheckAxes();
    }

    private void Update()
    {
        if(!_inputBlocked)
            CheckKeys();
    }

    private void CheckKeys()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (_inventory != null)
            {
                if(!_inventory.gameObject.activeSelf)
                    _inventory.Show();
                else
                    _inventory.Hide();
            }
        }
    }

    private void CheckAxes()
    {
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");

        Move(hInput, vInput);
        
        MoveAnimation(hInput, vInput, _lastHInput, _lastVInput);

        _lastHInput = hInput;
        _lastVInput = vInput;
    }

    private void Move(float h, float v)
    {
        _model.Move(h,v);
    }

    private void MoveAnimation(float h, float v, float lastH, float lastV)
    {
        //If H is not zero, it sends the given value to the Animator
        //If it's zero, checks the corresponding last value:
        //-- If the last value is different than zero then I send the threshold value, to set correct Idle animation
        //-- If the last value is zero, then, I don't modify the variable
        
        // === The last is also applicable for V ===
        
        if (Mathf.Abs(h) > ZERO_THRESHOLD)
        {
            if (Mathf.Abs(_yAnim) == idleThreshold)
                _yAnim = 0;
            
            _xAnim = h;
        }
        else if(lastH > ZERO_THRESHOLD)
            _xAnim = idleThreshold;
        else if (lastH < -ZERO_THRESHOLD)
            _xAnim = -idleThreshold;

        if (Mathf.Abs(v) > ZERO_THRESHOLD)
        {
            if (Mathf.Abs(_xAnim) == idleThreshold)
                _xAnim = 0;
            
            _yAnim = v;
        }
        else if(lastV > ZERO_THRESHOLD)
            _yAnim = idleThreshold;
        else if (lastV < -ZERO_THRESHOLD)
            _yAnim = -idleThreshold;
        
        _view.SetMovementAxes(_xAnim, _yAnim);
    }

    #region Shop Customer interface methods
    
    public void BoughtItem(Item item)
    {
        _inventory.AddItem(item);
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if (_coinsHandler.GetCoinsAmount() >= spendGoldAmount)
        {
            _coinsHandler.SpendCoins(spendGoldAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfEnoughSpaceInInventory()
    {
        return _inventory.CheckAvailableSpace();
    }

    public Item[] GetCustomerInventory()
    {
        return _inventory.GetItems();
    }

    public void SellItem(Item item)
    {
        _coinsHandler.EarnCoins(item.sellValue);
        _inventory.RemoveItem(item);
    }
    #endregion
}
