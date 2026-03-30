using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoPENetConnect
{
    /// <summary>
    /// 手控盒命令执行器接口（用于与控制器交互）
    /// </summary>
    public interface IRmcCommandExecutor
    {

        /// <summary>调整速度（delta 为正增加，负减少）</summary>
        void AdjustSpeed(double delta);
        /// <summary>向上移动（速度 mm/s）</summary>
        void MoveUp(double speed);
        /// <summary>向下移动（速度 mm/s）</summary>
        void MoveDown(double speed);
        /// <summary>停止移动</summary>
        void Stop();
        /// <summary>激活伺服</summary>
        void Activate();
        /// <summary>停用伺服</summary>
        void Deactivate();
        /// <summary>是否已激活</summary>
        bool IsActivated { get; }

        double GetCurrentSpeed();
    }
}
