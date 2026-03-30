using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doli.DoPE10;

namespace DoPENetConnect
{
    /// <summary>
    /// 手控盒按键处理器
    /// </summary>
    public class RmcHandler
    {
        private readonly IRmcCommandExecutor _executor;
        private double _moveSpeed;
        private const double SPEED_STEP = 0.5;   // 每次旋钮旋转的速度变化量 (mm/s)


        /// <summary>构造函数</summary>
        /// <param name="executor">命令执行器</param>
        /// <param name="moveSpeed">点动速度（mm/s），默认 2</param>
        public RmcHandler(IRmcCommandExecutor executor, double moveSpeed = 2.0)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _moveSpeed = moveSpeed;
        }

        /// <summary>设置或获取点动速度（mm/s）</summary>
        public double MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }

        /// <summary>
        /// 处理 DoPE OnKeyMsg 事件
        /// </summary>
        /// <param name="keyMsg">按键消息</param>
        //public void HandleKeyMsg(DoPE.OnKeyMsg keyMsg)
        //{
        //    if (keyMsg.DoPError != DoPE.ERR.NOERROR)
        //        return;

        //    // 上升键按下
        //    if ((keyMsg.NewKeys & 0x02) != 0)
        //    {
        //        _executor.MoveUp(_moveSpeed);
        //    }
        //    // 上升键释放
        //    if ((keyMsg.GoneKeys & 0x02) != 0)
        //    {
        //        _executor.Stop();
        //    }

        //    // 下降键按下
        //    if ((keyMsg.NewKeys & 0x04) != 0)
        //    {
        //        _executor.MoveDown(_moveSpeed);
        //    }
        //    // 下降键释放
        //    if ((keyMsg.GoneKeys & 0x04) != 0)
        //    {
        //        _executor.Stop();
        //    }

        //    // 停止键按下
        //    if ((keyMsg.NewKeys & 0x01) != 0)
        //    {
        //        _executor.Stop();
        //    }

        //    // F3 键按下：切换激活状态
        //    if ((keyMsg.NewKeys & 0x40) != 0)
        //    {
        //        if (_executor.IsActivated)
        //            _executor.Deactivate();
        //        else
        //            _executor.Activate();
        //    }

        //    // 可选：处理旋转按钮（0x08）和 +/- 按钮（0x20000）
        //}

        public void HandleKeyMsg(DoPE.OnKeyMsg keyMsg)
        {
            if (keyMsg.DoPError != DoPE.ERR.NOERROR)
                return;

            // 注意：旋钮旋转时，通常 DoPE_KEY_DPOTI（0x08）也会被置位
            // 而普通按键按下时，只有对应的键位（如 0x02、0x04）被置位
            // 所以通过判断 DPOTI 是否同时按下，来区分是旋钮还是普通按键
            bool isDigiPotiRotating = (keyMsg.NewKeys & 0x08) != 0;

            if (isDigiPotiRotating)
            {
                // 旋钮旋转：调整速度
                if ((keyMsg.NewKeys & 0x02) != 0)
                    _executor.AdjustSpeed(SPEED_STEP);     // 顺时针增加速度
                if ((keyMsg.NewKeys & 0x04) != 0)
                    _executor.AdjustSpeed(-SPEED_STEP);    // 逆时针减少速度
            }
            else
            {
                // 普通按键：执行升降
                if ((keyMsg.NewKeys & 0x02) != 0)  // 上升键按下
                {
                    double speed = _executor.GetCurrentSpeed();
                    _executor.MoveUp(speed);
                }
                if ((keyMsg.GoneKeys & 0x02) != 0) // 上升键释放
                    _executor.Stop();

                if ((keyMsg.NewKeys & 0x04) != 0)  // 下降键按下
                {
                    double speed = _executor.GetCurrentSpeed();
                    _executor.MoveDown(speed);
                }
                if ((keyMsg.GoneKeys & 0x04) != 0) // 下降键释放
                    _executor.Stop();
            }

            // 停止键、F3 键等保持不变
            if ((keyMsg.NewKeys & 0x01) != 0)
                _executor.Stop();

            if ((keyMsg.NewKeys & 0x40) != 0)
            {
                if (_executor.IsActivated)
                    _executor.Deactivate();
                else
                    _executor.Activate();
            }
        }
    }
}