namespace Game.Ecs.EcsThreads.Systems
{
    using Leopotam.EcsLite;

    public abstract class EcsThreadSystem<TThread, T1> : EcsThreadSystemBase, IProtoRunSystem
        where TThread : struct, IEcsThread<T1>
        where T1 : struct
    {
        EcsFilter _filter;
        ProtoPool<T1> _pool1;
        TThread _thread;
        ThreadWorkerHandler _worker;

        public void Run()
        {
            if (_filter == null)
            {
                var world = GetWorld(systems);
                _pool1 = world.GetPool<T1>();
                _filter = GetFilter(world);
                _thread = new TThread();
                _worker = Execute;
            }

            _thread.Init(
                _filter.GetRawEntities(),
                _pool1.GetRawDenseItems(), _pool1.GetRawSparseItems());
            SetData(systems, ref _thread);
            TaskThreadService.Run(_worker, _filter.GetEntitiesCount(), GetChunkSize(systems));
        }

        void Execute(int fromIndex, int beforeIndex)
        {
            _thread.Execute(fromIndex, beforeIndex);
        }

        protected virtual void SetData(IProtoSystems systems, ref TThread thread)
        {
        }
    }

    public abstract class EcsThreadSystem<TThread, T1, T2> : EcsThreadSystemBase, IProtoRunSystem
        where TThread : struct, IEcsThread<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        EcsFilter _filter;
        ProtoPool<T1> _pool1;
        ProtoPool<T2> _pool2;
        TThread _thread;
        ThreadWorkerHandler _worker;

        public void Run()
        {
            if (_filter == null)
            {
                var world = GetWorld(systems);
                _pool1 = world.GetPool<T1>();
                _pool2 = world.GetPool<T2>();
                _filter = GetFilter(world);
                _thread = new TThread();
                _worker = Execute;
            }

            _thread.Init(
                _filter.GetRawEntities(),
                _pool1.GetRawDenseItems(), _pool1.GetRawSparseItems(),
                _pool2.GetRawDenseItems(), _pool2.GetRawSparseItems());
            SetData(systems, ref _thread);
            TaskThreadService.Run(_worker, _filter.GetEntitiesCount(), GetChunkSize(systems));
        }

        void Execute(int fromIndex, int beforeIndex)
        {
            _thread.Execute(fromIndex, beforeIndex);
        }

        protected virtual void SetData(IProtoSystems systems, ref TThread thread)
        {
        }
    }

    public abstract class EcsThreadSystem<TThread, T1, T2, T3> : EcsThreadSystemBase, IProtoRunSystem
        where TThread : struct, IEcsThread<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        EcsFilter _filter;
        ProtoPool<T1> _pool1;
        ProtoPool<T2> _pool2;
        ProtoPool<T3> _pool3;
        TThread _thread;
        ThreadWorkerHandler _worker;

        public void Run()
        {
            if (_filter == null)
            {
                var world = GetWorld(systems);
                _pool1 = world.GetPool<T1>();
                _pool2 = world.GetPool<T2>();
                _pool3 = world.GetPool<T3>();
                _filter = GetFilter(world);
                _thread = new TThread();
                _worker = Execute;
            }

            _thread.Init(
                _filter.GetRawEntities(),
                _pool1.GetRawDenseItems(), _pool1.GetRawSparseItems(),
                _pool2.GetRawDenseItems(), _pool2.GetRawSparseItems(),
                _pool3.GetRawDenseItems(), _pool3.GetRawSparseItems());
            SetData(systems, ref _thread);
            TaskThreadService.Run(_worker, _filter.GetEntitiesCount(), GetChunkSize(systems));
        }

        void Execute(int fromIndex, int beforeIndex)
        {
            _thread.Execute(fromIndex, beforeIndex);
        }

        protected virtual void SetData(IProtoSystems systems, ref TThread thread)
        {
        }
    }

    public abstract class EcsThreadSystem<TThread, T1, T2, T3, T4> : EcsThreadSystemBase, IProtoRunSystem
        where TThread : struct, IEcsThread<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        EcsFilter _filter;
        ProtoPool<T1> _pool1;
        ProtoPool<T2> _pool2;
        ProtoPool<T3> _pool3;
        ProtoPool<T4> _pool4;
        TThread _thread;
        ThreadWorkerHandler _worker;

        public void Run()
        {
            if (_filter == null)
            {
                var world = GetWorld(systems);
                _pool1 = world.GetPool<T1>();
                _pool2 = world.GetPool<T2>();
                _pool3 = world.GetPool<T3>();
                _pool4 = world.GetPool<T4>();
                _filter = GetFilter(world);
                _thread = new TThread();
                _worker = Execute;
            }

            _thread.Init(
                _filter.GetRawEntities(),
                _pool1.GetRawDenseItems(), _pool1.GetRawSparseItems(),
                _pool2.GetRawDenseItems(), _pool2.GetRawSparseItems(),
                _pool3.GetRawDenseItems(), _pool3.GetRawSparseItems(),
                _pool4.GetRawDenseItems(), _pool4.GetRawSparseItems());
            SetData(systems, ref _thread);
            TaskThreadService.Run(_worker, _filter.GetEntitiesCount(), GetChunkSize(systems));
        }

        void Execute(int fromIndex, int beforeIndex)
        {
            _thread.Execute(fromIndex, beforeIndex);
        }

        protected virtual void SetData(IProtoSystems systems, ref TThread thread)
        {
        }
    }

    public abstract class EcsThreadSystemBase
    {
        protected abstract int GetChunkSize(IProtoSystems systems);
        protected abstract EcsFilter GetFilter(ProtoWorld world);
        protected abstract ProtoWorld GetWorld(IProtoSystems systems);
    }

    public interface IEcsThreadBase
    {
        void Execute(int fromIndex, int beforeIndex);
    }

    public interface IEcsThread<T1> : IEcsThreadBase
        where T1 : struct
    {
        void Init(
            int[] entities,
            T1[] pool1, int[] indices1);
    }

    public interface IEcsThread<T1, T2> : IEcsThreadBase
        where T1 : struct
        where T2 : struct
    {
        void Init(
            int[] entities,
            T1[] pool1, int[] indices1,
            T2[] pool2, int[] indices2);
    }

    public interface IEcsThread<T1, T2, T3> : IEcsThreadBase
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        void Init(
            int[] entities,
            T1[] pool1, int[] indices1,
            T2[] pool2, int[] indices2,
            T3[] pool3, int[] indices3);
    }

    public interface IEcsThread<T1, T2, T3, T4> : IEcsThreadBase
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        void Init(
            int[] entities,
            T1[] pool1, int[] indices1,
            T2[] pool2, int[] indices2,
            T3[] pool3, int[] indices3,
            T4[] pool4, int[] indices4);
    }
}